import { useState } from "react";
import Select from "react-select";
import useExpanse from "../hooks/useExpanse";
import { useCategoryContext } from "../contexts/CategoryContext";

function AddExpanse() {
  const { postExpanse } = useExpanse();
  const { categories } = useCategoryContext();
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [selectedInstallment, setSelectedInstallment] = useState(null);
  const [isChecked, setIsChecked] = useState(false);
  const [submitting, setSubmitting] = useState(false);

  const categoryOptions = categories.map((c) => ({ value: c.id, label: c.name }));
  const optionsInstallments = Array.from({ length: 12 }, (_, i) => ({ value: i + 1, label: i + 1 }));

  const handleSubmit = async (e) => {
    e.preventDefault();
    const fd = new FormData(e.currentTarget);

    if (!selectedCategory) return alert("Selecione uma categoria");
    const value = Number(fd.get("expenseValue"));
    const description = fd.get("expenseDescription")?.trim();
    const when = fd.get("when");

    if (Number.isNaN(value) || value <= 0) return alert("Valor inválido");
    if (!when) return alert("Informe a data");

    setSubmitting(true);
    try {
      await postExpanse({
        categoryId: selectedCategory.value,
        value,
        description,
        when,
        isCreditCard: isChecked
      });

      //e.currentTarget.reset();
      setSelectedCategory(null);
      setSelectedInstallment(null);
      setIsChecked(false);
    } catch (err) {
      alert("Erro ao salvar: " + err.message);
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <section>
      <h2>Adicionar Gasto</h2>
      <form onSubmit={handleSubmit} className="form-container">
        <input name="expenseValue" type="number" step="0.01" placeholder="Valor" />
        <input name="expenseDescription" type="text" placeholder="Descrição" />
        <Select options={optionsInstallments} placeholder="Parcelas" value={selectedInstallment} onChange={setSelectedInstallment} />
        <Select options={categoryOptions} placeholder="Categoria" value={selectedCategory} onChange={setSelectedCategory} />
        <input name="when" type="date" />
        <label><input type="checkbox" id="isCreditCard" checked={isChecked} onChange={e=>setIsChecked(e.target.checked)} /> Cartão de Crédito</label>
        <button type="submit" disabled={submitting}>{submitting ? "Salvando..." : "Adicionar"}</button>
      </form>
    </section>
  );
}

export default AddExpanse;
