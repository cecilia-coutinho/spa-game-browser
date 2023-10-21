import React, { useEffect, useState } from 'react';
import useFetch from './hooks/useFetch';
import authService from './api-authorization/AuthorizeService';


const Keyboard = ({ usedKeys, handleKeyup }) => {
    const [token, setToken] = useState(null);
    const { data: letters } = useFetch('api/Letters', token, () => {
        const enter = [{ key: 'Enter' }];
        const backspace = [{ key: 'Backspace' }];
        return [...enter, ...letters, ...backspace];
    });

    useEffect(() => {
        authService.getAccessToken()
            .then(tokenValue => {
                setToken(tokenValue);
            })
            .catch(error => {
                console.error('Error getting access token:', error.message);
            });
    }, []);

    return (
        <div className="keyboard">
            {letters && letters.map(letter => {
                const color = usedKeys[letter.key]
                const displayKey = letter.key === 'Backspace' ? 'DEL' : letter.key.toUpperCase();
                return (
                    <div
                        key={letter.key}
                        className={color}
                        onClick={() => handleKeyup({ key: letter.key })}
                    >
                        {displayKey}
                    </div>
                )
            })}
        </div>
    )
}

export default Keyboard;