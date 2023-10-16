import React, { useEffect, useState } from 'react';
import { getLetter } from './UseFetch/GetLetter';


const Keyboard = ({ usedKeys, handleKeyup }) => {
    const [letters, setLetters] = useState(null)

    useEffect(() => {
        getLetter()
            .then(getLetter => {
                setLetters(getLetter)
            })
    }, [])

    return (
        <div className="keyboard">
            {letters && letters.map(letter => {
                const color = usedKeys[letter.key]
                return (
                    <div
                        key={letter.key}
                        className={color}
                        onClick={() => handleKeyup({ key: letter.key })}
                    >
                        {letter.key}
                    </div>
                )
            })}
        </div>
    )
}

export default Keyboard;