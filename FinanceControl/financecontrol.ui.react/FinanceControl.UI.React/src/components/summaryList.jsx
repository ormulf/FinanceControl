function SummaryList({ list, onCategoryClick }) {
  if (!list || !list.length) return <tr><td colSpan={2}>Nenhuma categoria</td></tr>;
  
  return (
    <>
      {list.map((c) => (
        <tr key={c.id} className="clickable-row" onClick={() => onCategoryClick?.(c.id, c.name)}>
          <td>{c.name}</td>
          <td><span>{c.totalExpanses}</span> / <span>{c.limit}</span></td>
        </tr>        
      ))}
    </>
  );
}

export default SummaryList;
