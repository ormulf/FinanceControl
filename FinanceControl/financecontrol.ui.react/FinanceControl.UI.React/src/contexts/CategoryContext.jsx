import React, { createContext, useContext, useEffect, useState, useCallback } from "react";
import loadingStatus from "../helpers/loadingStatus";
import { apiGet, apiPost } from "../api";

const CategoryContext = createContext();
export const useCategoryContext = () => useContext(CategoryContext);

export function CategoryProvider({ children }) {
  const [categories, setCategories] = useState([]);
  const [summary, setSummary] = useState(null);
  const [status, setStatus] = useState(loadingStatus.idle);
  const [error, setError] = useState(null);

  const fetchCategories = useCallback(async () => {
    try {
      const data = await apiGet("/category");
      setCategories(data || []);
    } catch (err) {
      setError(err.message);
    }
  }, []);

  const fetchSummary = useCallback(async (month = 12, year = 2025) => {
    setStatus(loadingStatus.loading);
    try {
      const data = await apiGet(`/Category/summary?month=${month}&year=${year}`);
      setSummary(data);
      setStatus(loadingStatus.loaded);
    } catch (err) {
      setError(err.message);
      setStatus(loadingStatus.error);
    }
  }, []);

  useEffect(() => {
    fetchCategories();
    fetchSummary();
  }, [fetchCategories, fetchSummary]);

  const postCategory = useCallback(
    async (category) => {
      const optimistic = { id: crypto.randomUUID(), ...category };
      setCategories((prev) => [...prev, optimistic]);
      try {
        const saved = await apiPost("/category", category);
        setCategories((prev) => prev.map((c) => (c.id === optimistic.id ? saved : c)));
        await fetchSummary();
        return saved;
      } catch (err) {
        setCategories((prev) => prev.filter((c) => c.id !== optimistic.id));
        setError(err.message);
        throw err;
      }
    }, [fetchSummary]
  );

  const postExpanse = useCallback(async (expanse) => {
    try {
      await apiPost("/expanse", expanse);
      await fetchSummary();
    } catch (err) {
      setError(err.message);
      throw err;
    }
  }, [fetchSummary]);

  const refreshSummary = useCallback(() => fetchSummary(), [fetchSummary]);

  return (
    <CategoryContext.Provider value={{
      categories, summary, status, error,
      postCategory, postExpanse, refreshSummary
    }}>
      {children}
    </CategoryContext.Provider>
  );
}
