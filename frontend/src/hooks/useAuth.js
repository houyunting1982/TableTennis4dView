import React, { useState, createContext, useContext } from 'react';
import { useLocalStorage } from './useLocalStorage';
import { loginAsync } from '../services/apis/usersApi';

const AuthContext = createContext(null);
export const AuthProvider = ({ children }) => {
    const { getItem, setItem, removeItem } = useLocalStorage();

    const value = getItem('credential');
    const valueJson = value ? JSON.parse(value) : {};

    const [authed, setAuthed] = useState(!!valueJson.name);
    const [userName, setUserName] = useState(valueJson.name);
    const [token, setToken] = useState(valueJson.token);
    const [userId, setUserId] = useState(valueJson.userId);

    const login = async (username, password) => {
        try {
            const data = await loginAsync(username, password);
            console.log(data);
            const { name, token, userId } = data.data;
            setUserName(name);
            setToken(token);
            setUserId(userId);
            setItem('credential', JSON.stringify({ name, token, userId }));
            setAuthed(true);
        } catch (error) {
            console.log(error);
        }
    };

    const logout = async () => {
        const result = await fakeAsyncLogout();
        if (result) {
            console.log(`The User ${userName} has logged out`);
            setUserName(null);
            setToken(null);
            setUserId(null);
            removeItem('credential');
            setAuthed(false);
        }
    };

    /// Mock Async Login API call.
    // TODO: Replace with your actual login API Call code
    const fakeAsyncLogin = async (username, password) => {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(`Logged In ${username} ${password}`);
            }, 300);
        });
    };

    // Mock Async Logout API call.
    // TODO: Replace with your actual logout API Call code
    const fakeAsyncLogout = async () => {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve('The user has successfully logged on the server');
            }, 300);
        });
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
