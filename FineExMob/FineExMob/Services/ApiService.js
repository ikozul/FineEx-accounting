import Axios from "axios";

const API_URI = 'http://localhost:49675/api/'

export async function post(body, url) {
    const result = await Axios({
        method: 'post',
        url: `${API_URI}${url}/`,
        headers: {
            Accept: '*/*',
            'Content-Type': 'application/json'
        },
        data: body,
    });
    if(!result) {
        return null;
    }
    return result.data;

}

export async function get(url) {
    const result = await Axios({
        method: 'get',
        url: `${API_URI}${url}/`,
        headers: {
            Accept: '*/*',
            'Content-Type': 'application/json'
        },
    });
    if(!result) {
        return null;
    }
    return result.data;
}

export async function put(body, url) {
    const result = await Axios({
        method: 'put',
        url: `${API_URI}${url}`,
        headers: {
            Accept: '*/*',
            'Content-Type': 'application/json'
        },
        data: body
    });
    if(!result) {
        return null;
    }
    return result.data;
}