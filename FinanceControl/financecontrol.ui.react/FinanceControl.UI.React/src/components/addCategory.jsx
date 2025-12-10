import { useState } from "react";
import Select from "react-select";

function AddCategory({postCategory}) {


  const [selectedCategoryType, setSelectedCategoryType] = useState(null);

  const options = [
    { value: "0", label: "Indispensável" },
    { value: "1", label: "Assinatura" },
    { value: "2", label: "Extra" },
  ];

  const categorySubmitAction = async (formData) => {
    await postCategory({
      name: formData.get("categoryName"),
      limit: formData.get("limitValue"),
      type: selectedCategoryType ? selectedCategoryType.value : null, 
    });
  };

  return (
    <>
      <section>
        <h2>Adicionar Categoria</h2>

        <form action={categorySubmitAction} className="form-container">
          <input
            id="categoryName"
            name="categoryName"
            type="text"
            placeholder="Nome da Categoria"
          />

          <Select
            options={options}
            placeholder="Tipo"
            value={selectedCategoryType}
            onChange={setSelectedCategoryType} 
            className="react-select-container"
            classNamePrefix="react-select"
          />

          <input
            id="limitValue"
            name="limitValue"
            type="number"
            step="0.01"
            placeholder="Valor Limite"
          />

          <button type="submit">Adicionar</button>
        </form>
      </section>
    </>
  );
}

export default AddCategory;
