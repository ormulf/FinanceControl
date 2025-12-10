import { useEffect,useState } from "react";
import loadingStatus from "../helpers/loadingStatus"

const useCategory = () => {
  const [categories, setCategories] = useState([]);
  const [categorySummary, setCategorySummary] = useState([]);
  const [loadingStateCategorySummary, setLoadingStateCategorySummary] =
    useState(loadingStatus.isLoading);

  

    useEffect(() => {
      const fetchCategories = async () => {
      const rsp = await fetch("https://localhost:7176/api/category");
      const data = await rsp.json();
      setCategories(data);
    };
    fetchCategories();
  }, []);

    const fetchCategorySummary = async () => {
    setLoadingStateCategorySummary(loadingStatus.isLoading);
    const rsp = await fetch("https://localhost:7176/api/Category/summary?month=12&year=2025");
    const data = await rsp.json();
    setCategorySummary(data);
    setLoadingStateCategorySummary(loadingStatus.loaded);
    };

    useEffect(() => {

      fetchCategorySummary();
    }, []);

  // ✔ ADICIONAR CATEGORIA OTIMISTICAMENTE
  const postCategory = async (category) => {
    // 1) Atualiza o estado otimisticamente
    const optimisticCategory = {
      id: crypto.randomUUID(), // id temporário
      ...category
    };

    setCategories(prev => [...prev, optimisticCategory]);

    // 2) Envia ao servidor
    const rsp = await fetch("https://localhost:7176/api/category", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(category),
    });

    // 3) Se falhar → desfaz
    if (!rsp.ok) {
      setCategories(prev => prev.filter(c => c.id !== optimisticCategory.id));
      alert("Ocorreu um erro ao salvar no servidor!");
      return;
    }

    // 4) Se sucesso → pega a versão oficial do backend
    const saved = await rsp.json();

    // substitui o item otimista pelo item real
    setCategories(prev =>
      prev.map(c => (c.id === optimisticCategory.id ? saved : c))
    );
  };

  const refreshSummary = async () => {

    await fetchCategorySummary();
  
  };

  return { categories, categorySummary, postCategory, loadingStateCategorySummary, refreshSummary };
};

export default useCategory;
