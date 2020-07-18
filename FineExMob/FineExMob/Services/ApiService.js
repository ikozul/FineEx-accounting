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
    // const result = await fetch(`http://localhost:49675/api/companies`, {
    //     method: 'GET',
    //     // headers: {
    //     //     Accept: '*/*',
    //     //     'Content-Type': 'application/json'
    //     // },
    //     keepalive: true,
    //     headers: {
    //         accept: ''
    //     }
    // });
    // console.log(JSON.stringify(result));
    console.log('test');
    var requestOptions = {
        method: 'GET',
        redirect: 'follow'
    };

    const result = await Axios({
        url: "http://localhost:49675/api/companies",
        method: 'GET',
        redirect: 'follow',
    });
    console.log('result', result);
    console.log('result.json()', result.json());
    console.log('result.json()', JSON.stringify(result));
    console.log('result.json()', result.toString());
    // return result.json();
}