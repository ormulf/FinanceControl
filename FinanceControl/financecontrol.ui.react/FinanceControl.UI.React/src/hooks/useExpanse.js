const useExpanse = () => {
    const postExpanse = async (expanse) => {
        await fetch("https://localhost:7176/api/expanse", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(expanse)
    });
    }
    return { postExpanse };
};
export default useExpanse;