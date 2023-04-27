import axios from 'axios';

export async function getTechniquesbyPlayerId(playerId, token ) {
    return axios(`/api/Techniques/Player/${playerId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}
