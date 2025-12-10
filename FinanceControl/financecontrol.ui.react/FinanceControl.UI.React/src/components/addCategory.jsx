import { useState } from "react";
import Select from "react-select";
import { useCategoryContext } from "../contexts/CategoryContext";

const options = [
  { value: 0, label: "Indispensável" },
  { value: 1, label: "Assinatura" },
  { value: 2, label: "Extra" },
];

function AddCategory() {
  const { postCategory } = useCategoryContext();
  const [selectedType, setSelectedType] = useState(null);
  const [submitting, setSubmitting] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const form = e.currentTarget;
    const fd = new FormData(form);
    const name = fd.get("categoryName")?.trim();
    const limit = Number(fd.get("limitValue"));

    if (!name) return alert("Informe o nome da categoria");
    if (!selectedType) return alert("Selecione o tipo");
    if (Number.isNaN(limit)) return alert("Informe um valor limite válido");

    setSubmitting(true);
    try {
      await postCategory({ name, limit, type: selectedType.value });
      form.reset();
      setSelectedType(null);
    } catch (err) {
      alert("Erro ao salvar: " + err.message);
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <section>
      <h2>Adicionar Categoria</h2>
      <form onSubmit={handleSubmit} className="form-container">
        <input name="categoryName" type="text" placeholder="Nome da Categoria" />
        <Select options={options} placeholder="Tipo" value={selectedType} onChange={setSelectedType} />
        <input name="limitValue" type="number" step="0.01" placeholder="Valor Limite" />
        <button type="submit" disabled={submitting}>{submitting ? "Salvando..." : "Adicionar"}</button>
      </form>
    </section>
  );
}

export default AddCategory;
