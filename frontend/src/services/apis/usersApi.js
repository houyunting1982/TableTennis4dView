import axios from 'axios';

export async function loginAsync(username, password) {
    return axios(`/api/Auth/Login`, {
        method: 'POST',
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        data: {
            username,
            password
        }
    });
}

export async function getUserDetail(userId, token) {
    return axios(`/api/User/GetUserDetails/${userId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}


export async function AddPlayerToUser(id, playerId, token) {
    return axios(`/api/User/AssignUserPlayer`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        data: {
            id,
            playerId
        }
    });
}