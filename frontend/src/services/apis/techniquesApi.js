import axios from 'axios';

export async function getTechniquesbyPlayerId(playerId, token) {
    return axios(`/api/Techniques/Player/${playerId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getAllTechniques(token) {
    return axios(`/api/Techniques`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function createTechnique(techniqueFormData, token) {
    return axios(`/api/Techniques`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/form-data',
            Authorization: `Bearer ${token}`
        },
        data: techniqueFormData
    });
}