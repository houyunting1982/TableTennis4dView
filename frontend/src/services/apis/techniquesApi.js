import axios from 'axios';

export async function getTechniquesbyPlayerId(playerId, token ) {
    return axios(`https://localhost:7142/api/Techniques/Player/${playerId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}
