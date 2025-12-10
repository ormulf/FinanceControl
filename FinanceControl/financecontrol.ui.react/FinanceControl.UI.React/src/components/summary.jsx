import { useState } from "react";
import SummaryList from "./summaryList";
import Select from "react-select";
import CategoryExpanseList from "./CategoryExpanseList";
import { useCategoryContext } from "../contexts/CategoryContext";

function Summary() {
  const { summary } = useCategoryContext();
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [selectedCategoryName, setSelectedCategoryName] = useState(null);

  if (!summary) return <p>Sem dados</p>;

  const openCategory = async (categoryId,categoryName) => {
    console.log(categoryId);
    setSelectedCategory(categoryId);
    setSelectedCategoryName(categoryName)
  }

  const closeCategoryModal = () => {
    setSelectedCategory(null);
  }

  return (
    <section className="summary-section">
      <header className="summary-header">
        <h1>Dezembro 2025</h1>
        <p>{summary.totalExpanses} / {summary.budget}</p>
        <Select placeholder="Selecione mês/ano" />
      </header>

      <table className="main-table">
        <thead>
          <tr>
            <th>Indispensável</th>
            <th>Assinatura</th>
            <th>Extra</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td><table className="inner-table"><tbody><SummaryList list={summary.indispensable} onCategoryClick={openCategory} /></tbody></table></td>
            <td><table className="inner-table"><tbody><SummaryList list={summary.signature} onCategoryClick={openCategory} /></tbody></table></td>
            <td><table className="inner-table"><tbody><SummaryList list={summary.extra} onCategoryClick={openCategory} /></tbody></table></td>
          </tr>
        </tbody>
      </table>
      {selectedCategory && (
        <CategoryExpanseList
          categoryId = {selectedCategory}
          categoryName = {selectedCategoryName}
          onClose = {closeCategoryModal}
        />
      )}
    </section>
    
  );
}

export default Summary;
