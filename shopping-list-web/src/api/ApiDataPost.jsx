import {useState, useEffect} from "react";

function ApiDataPost(endpoint) {
    const element = document.querySelector('#post-request-error-handling .article-id');
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ title: 'Fetch POST Request Example' })
    };

    fetch(`http://localhost:5118/api/shopping-list/${endpoint}`, requestOptions)
        .then(async response => {
            const isJson = response.headers.get('content-type')?.includes('application/json');
            const data = isJson && await response.json();

            if (!response.ok) {
                const error = (data && data.message) || response.status;
                return Promise.reject(error);
            }

            element.innerHTML = data.id;
        })
        .catch(error => {
            element.parentElement.innerHTML = `Error: ${error}`;
            console.error('There was an error!', error);
        });
}

export default ApiDataPost;