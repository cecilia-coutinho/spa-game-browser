import React, { useEffect, useState } from 'react';
import { getLetter } from './UseFetch/GetLetter';


const Keyboard = ({ usedKeys, handleKeyup }) => {
    const [letters, setLetters] = useState(null)

    useEffect(() => {
        getLetter()
            .then(getLetter => {

                const enter = [
                    { key: 'Enter' }
                ];
                const backspace = [
                    { key: 'Backspace' }
                ];
                setLetters([...enter, ...getLetter, ...backspace])
            })
    }, [])

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