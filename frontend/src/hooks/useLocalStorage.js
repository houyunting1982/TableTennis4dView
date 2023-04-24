export const useLocalStorage = () => {
    const setItem = (key, value) => {
        localStorage.setItem(key, value);
    };

    const getItem = (key) => {
        const value = localStorage.getItem(key);
        return value;
    };

    const removeItem = (key) => {
        localStorage.removeItem(key);
    };

    return { setItem, getItem, removeItem };
};
