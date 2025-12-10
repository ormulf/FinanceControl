import "./App.css";
import { CategoryProvider } from "./contexts/CategoryContext";
import AddCategory from "./components/addCategory";
import AddExpanse from "./components/addExpanse";
import Summary from "./components/summary";
import { useCategoryContext } from "./contexts/CategoryContext";
import LoadingIndicator from "./components/loadingIndicator";
import loadingStatus from "./helpers/loadingStatus";

function AppInner() {
  const { status } = useCategoryContext();

  if (status !== loadingStatus.loaded) return <LoadingIndicator />;

  return (
    <>      
      <AddCategory />
      <AddExpanse />
      <Summary />
    </>
  );
}

export default function App() {
  return (
    <CategoryProvider>
      <AppInner />
    </CategoryProvider>
  );
}
