function SummaryList({categoryTypeSummaryList}) {
    console.log('list');
    console.log(categoryTypeSummaryList);
    return(
        <>

            {categoryTypeSummaryList.map((c) => (
              <tr key={c.id}><td>{c.name}</td><td><span>{c.totalExpanses}</span> / <span>{c.limit}</span></td></tr>
            ))}
            
        
        </>
    );
};

export default SummaryList;