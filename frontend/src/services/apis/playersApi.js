import axios from 'axios';

export async function getUnPurchasedPlayers(userId, token ) {
    return axios(`https://localhost:7142/api/Players/Unpurchased/${userId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getPlayerById(playerId, token ) {
    return axios(`https://localhost:7142/api/Players/${playerId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}
