import { useState, useEffect } from 'react';
import axios from 'axios';
import authService from '../api-authorization/AuthorizeService';

const useFetch = (url, token = null) => {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        // Create an abort controller to handle cleanup
        const source = axios.CancelToken.source();

        // Fetch data from the specified URL
        const fetchData = () => {

            if (token) {
                authService.getAccessToken()
                .then(token => {
                    return axios.get(url, { cancelToken: source.token,
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
            })
                            .then(response => {
                                //console.log(response.data);
                                setData(response.data);
                                setLoading(false);
                                setError(null);
                            })
                            .catch(err => {
                                if (!axios.isCancel(err)) {
                                    setLoading(false);
                                    setError(err.message);
                                }
                            });
            } else {
                axios.get(url, { cancelToken: source.token})
                    .then(response => {
                        //console.log(response.data);
                        setData(response.data);
                        setLoading(false);
                        setError(null);
                    })
                    .catch(err => {
                        if (!axios.isCancel(err)) {
                            setLoading(false);
                            setError(err.message);
                        }
                    });
            }
        };

        fetchData();

        // Cleanup function to cancel request when the component unmounts
        return () => source.cancel();
    }, [url, token]);

    return { data, loading, error };
};

export default useFetch;
