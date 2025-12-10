export const API_BASE = import.meta.env.VITE_API_BASE || "https://localhost:7176/api";

async function handleResponse(res) {
  if (!res.ok) {
    const text = await res.text().catch(() => null);
    throw new Error(text || res.statusText || "Network error");
  }
  if (res.status === 204) return null;
  return res.json();
}

export const apiGet = (path) => fetch(`${API_BASE}${path}`).then(handleResponse);
export const apiPost = (path, body) =>
  fetch(`${API_BASE}${path}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(body),
  }).then(handleResponse);