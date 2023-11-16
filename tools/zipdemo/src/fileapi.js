import axios from 'axios';

export async function getPlayersFile() {
    return axios(`https://localhost:7142/Players/test-zip.zip`, {
        method: 'GET',
        responseType: 'arraybuffer'
        // headers: {
        //     'Content-Type': 'application/json',
        // }
    });
}
