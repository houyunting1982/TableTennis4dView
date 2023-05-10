import React, { useState, createContext, useContext } from 'react';
import { useLocalStorage } from './useLocalStorage';
import { loginAsync } from '../services/apis/usersApi';
import { isExpired } from 'react-jwt';

const AuthContext = createContext(null);
export const AuthProvider = ({ children }) => {
    const { getItem, setItem, removeItem } = useLocalStorage();

    const value = getItem('credential');
    const valueJson = value ? JSON.parse(value) : {};

    const [authed, setAuthed] = useState(valueJson.token && !isExpired(valueJson.token));
    const [userName, setUserName] = useState(valueJson.name);
    const [token, setToken] = useState(valueJson.token);
    const [userId, setUserId] = useState(valueJson.userId);

    const login = async (username, password) => {
        try {
            const data = await loginAsync(username, password);
            const { name, token, userId } = data.data;
            setUserName(name);
            setToken(token);
            setUserId(userId);
            setItem('credential', JSON.stringify({ name, token, userId }));
            setAuthed(true);
        } catch (error) {
            return error.response;
        }
    };

    const logout = () => {
        console.log(`The User ${userName} has logged out`);
        setUserName(null);
        setToken(null);
        setUserId(null);
        removeItem('credential');
        setAuthed(false);
    };
    return (
        <AuthContext.Provider
            value={{
                authed,
                setAuthed,
                login,
                logout,
                userName,
                token,
                userId
            }}
        >
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);
