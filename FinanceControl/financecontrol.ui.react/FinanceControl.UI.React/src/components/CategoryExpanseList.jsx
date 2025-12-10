import "../style/CategoryExpanseList.css";
import loadingStatus from "../helpers/loadingStatus";
import { apiGet } from "../api";
import LoadingIndicator from "./loadingIndicator";
import React, {  useState, useCallback,useEffect } from "react";

function CategoryExpanseList({ categoryId, categoryName, onClose }) {
    console.log('CategoryExpanseList');
    console.log(categoryId);
    const [expanses, setExpanses] = useState([]);
    const [status, setStatus] = useState(loadingStatus.idle);
    

    const fetchExpanses = useCallback(async () => {
        setStatus(loadingStatus.loading);
        const data = await apiGet("/Expanse/by-category/"+ categoryId);        
        setExpanses(data || []);        
        setStatus(loadingStatus.loaded);
    }, []);

    useEffect(() => {
        fetchExpanses();
      }, [fetchExpanses,categoryId]);

    if (!categoryId) {
        return null;
    }
        

    if (status !== loadingStatus.loaded) return <LoadingIndicator />;

    return (
    <div className="expanse-overlay">
        <div className="expanse-container">

        <header className="expanse-header">
            <h2>Gastos — {categoryName}</h2>
            <button className="close-btn" onClick={onClose}>✕</button>
        </header>

        {(!expanses || expanses.length === 0) && (
            <p className="empty-msg">Nenhum gasto registrado nesta categoria.</p>
        )}

        <table className="expanse-table">
            <thead>
            <tr>
                <th>Valor</th>
                <th>Descrição</th>
                <th>Data</th>
                <th>Cartão</th>
            </tr>
            </thead>

            <tbody>
            {expanses.map(exp => (
                <tr key={exp.id}>
                <td>R$ {exp.value.toFixed(2)}</td>
                <td>{exp.description}</td>
                <td>{new Date(exp.when).toLocaleDateString("pt-BR")}</td>
                <td>{exp.isCreditCard ? "Sim" : "Não"}</td>
                </tr>
            ))}
            </tbody>
        </table>

        </div>
    </div>
  );
}

export default CategoryExpanseList;
