import axios from 'axios';

export async function getUnPurchasedPlayers(userId, token) {
    return axios(`/api/Players/Unpurchased/${userId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getPlayerById(playerId, token) {
    return axios(`/api/Players/${playerId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getAllPlayers(token) {
    return axios(`/api/Players`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getAllPlayersSimple(token) {
    return axios(`/api/Players/simple`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function updatePlayer(updatedPlayer, token) {
    return axios(`/api/Players/${updatedPlayer.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        data: updatedPlayer
    });
}

export async function deletePlayerById(playerId, token) {
    return axios(`/api/Players/${playerId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    });
}

export async function createPlayer(newPlayer, token) {
    return axios(`/api/Players`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        data: newPlayer
    });
}
