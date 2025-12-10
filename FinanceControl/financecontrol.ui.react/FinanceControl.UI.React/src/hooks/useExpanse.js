import { useCategoryContext } from "../contexts/CategoryContext";

const useExpanse = () => {
  const { postExpanse } = useCategoryContext();
  return { postExpanse };
};

export default useExpanse;
