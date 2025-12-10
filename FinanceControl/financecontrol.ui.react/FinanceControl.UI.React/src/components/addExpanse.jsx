import { useState } from "react";
import Select from "react-select";
import useExpanse from "../hooks/useExpanse";

function AddExpanse({categories}) {
    const { postExpanse } = useExpanse();
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [selectedInstallment, setSelectedInstallment] = useState(null);
    const [isChecked, setIsChecked] = useState(false);

    const handleCheckboxChange = (event) => {
        setIsChecked(event.target.checked);
    };


    const optionsInstallments = Array.from({ length: 12 }, (_, i) => ({
        value: i + 1,
        label: i + 1
    }));

    const categoryOptions = categories.map(c => ({
        value: c.id,
        label: c.name
    }));

    const expanseSubmitAction = async (formData) => {
        await postExpanse({
        categoryId: selectedCategory ? selectedCategory.value : null,
        value: formData.get("expenseValue"),
        description: formData.get("expenseDescription"),
        when: formData.get("when"),
        isCreditCard: isChecked 
        });
    };
    
    return(
        <>

            <section>
                <h2>Adicionar Gasto</h2>

                <form  action={expanseSubmitAction} className="form-container">
                <input
                    name="expenseValue"
                    type="number"
                    step="0.01"
                    placeholder="Valor"
                />

                <input
                    name="expenseDescription"
                    type="text"
                    placeholder="Descrição"
                />

                <Select
                    options={optionsInstallments}
                    placeholder="Parcelas"
                    value={selectedInstallment}
                    onChange={setSelectedInstallment} 
                    className="react-select-container"
                    classNamePrefix="react-select"
                />

                <Select
                    options={categoryOptions}
                    placeholder="Categoria"
                    value={selectedCategory}
                    onChange={setSelectedCategory} 
                    className="react-select-container rscCategory"
                    classNamePrefix="react-select"
                />

                <input name="when" type="date" placeholder="Quando" />

                <input id="isCreditCard" type="checkbox" className="checkbox" onChange={handleCheckboxChange}/> Cartão de Crédito

                <button type="submit">Adicionar</button>
                </form>
            </section>

        </>
    );

}

export default AddExpanse;