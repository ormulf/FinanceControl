import "./App.css";
import AddCategory from "./components/addCategory";
import AddExpanse from "./components/addExpanse";
import Summary from "./components/summary";
import useCategory from "./hooks/useCategory";
import LoadingIndicator from "./components/loadingIndicator";
import loadingStatus from "./helpers/loadingStatus";

function App() {  
  const { categories, categorySummary, postCategory, loadingStateCategorySummary, refreshSummary } = useCategory();
  if (loadingStateCategorySummary !== loadingStatus.loaded){
    return <LoadingIndicator loadingState={loadingStateCategorySummary} />
  }

  const onRefreshClick = () => {
    refreshSummary();
  };
        
  return (
    <>
      <button
          className="btn btn-primary"
          onClick={onRefreshClick}
        >
          Refresh
        </button>
      <AddCategory postCategory={postCategory} refreshSummary={refreshSummary}/>
      <AddExpanse categories={categories} refreshSummary={refreshSummary} />
      <Summary categorySummary={categorySummary} />
      
    </>
  );
}

export default App;
