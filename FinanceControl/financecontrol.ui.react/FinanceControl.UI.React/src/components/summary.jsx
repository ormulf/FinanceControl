import Select from "react-select";
import SummaryList from "./summaryList"
function Summary({categorySummary}) {

    console.log(categorySummary);
    console.log(categorySummary.totalExpanses);
    console.log(categorySummary.budget);
    console.log(categorySummary.indispensable);
    return(
        <>
        
            <section className="summary-section">
            <header className="summary-header">
            <h1>Dezembro 2025</h1>
            <p>{categorySummary.totalExpanses} / {categorySummary.budget}</p>
            <Select placeholder="Selecione Mês/Ano" />
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
                <td>
                    <table className="inner-table">
                    <tbody>
                        <SummaryList categoryTypeSummaryList={categorySummary.indispensable}></SummaryList>
                    </tbody>
                    </table>
                </td>
                <td>
                    <table className="inner-table">
                    <tbody>
                        <SummaryList categoryTypeSummaryList={categorySummary.signature}></SummaryList>
                    </tbody>
                    </table>
                </td>
                <td>
                    <table className="inner-table">
                    <tbody>
                        <SummaryList categoryTypeSummaryList={categorySummary.extra}></SummaryList>
                    </tbody>
                    </table>
                </td>
                </tr>
            </tbody>
            
            </table>
        </section>
        
        </>
    );

};

export default Summary;