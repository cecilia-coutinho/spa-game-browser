import { useState } from 'react';

const UseWordle = (solution) => {
    const [turn, setTurn] = useState(0);
    const [currentGuess, setCurrentGuess] = useState('');
    const [guesses, setGuesses] = useState([...Array(6)]);
    const [history, setHistory] = useState([]);
    const [isCorrect, setIsCorrect] = useState(false);
    const [usedKeys, setUsedKeys] = useState({});

    const formatGuess = () => {
        let solutionArray = [...solution]
        let formattedGuess = [...currentGuess].map((letter) => {
            return { key: letter, color: 'grey' }
        })

        formattedGuess.forEach((letter, i) => {
            if (solution[i] === letter.key) {
                formattedGuess[i].color = 'green'
                solutionArray[i] = null
            }
        })

        formattedGuess.forEach((letter, i) => {
            if (solutionArray.includes(letter.key) && letter.color !== 'green') {
                formattedGuess[i].color = 'yellow'
                solutionArray[solutionArray.indexOf(letter.key)] = null
            }
        })

        return formattedGuess
    }

    const addNewGuess = (formattedGuess) => {
        if (currentGuess === solution) {
            setIsCorrect(true)
        }
        setGuesses(prevGuesses => {
            let newGuesses = [...prevGuesses]
            newGuesses[turn] = formattedGuess
            return newGuesses
        })
        setHistory(prevHistory => {
            return [...prevHistory, currentGuess]
        })
        setTurn(prevTurn => {
            return prevTurn + 1
        })
        setUsedKeys(prevUsedKeys => {
            formattedGuess.forEach(letter => {
                const currentColor = prevUsedKeys[letter.key]

                if (letter.color === 'green') {
                    prevUsedKeys[letter.key] = 'green'
                    return
                }
                if (letter.color === 'yellow' && currentColor !== 'green') {
                    prevUsedKeys[letter.key] = 'yellow'
                    return
                }
                if (letter.color === 'grey' && currentColor !== ('green' || 'yellow')) {
                    prevUsedKeys[letter.key] = 'grey'
                    return
                }
            })

            return prevUsedKeys
        })
        setCurrentGuess('')
    }

    const handleKeyup = ({ key }) => {
        if (key === 'Enter') {
            if (turn > 5) {
                console.log('you used all your guesses!')
                return
            }

            // do not allow duplicate words
            if (history.includes(currentGuess)) {
                console.log('you already tried that word.')
                return
            }

            if (currentGuess.length !== 5) {
                console.log('word must be 5 chars.')
                return
            }
            const formatted = formatGuess()
            addNewGuess(formatted)
        }
        if (key === 'Backspace') {
            setCurrentGuess(prev => prev.slice(0, -1))
            return
        }
        // ensure input is a single letter
        if (/^[A-Za-z]$/.test(key)) {
            if (currentGuess.length < 5) {
                setCurrentGuess(prev => prev + key)
            }
        }
    }

    return { turn, currentGuess, guesses, isCorrect, usedKeys, handleKeyup }
};

export default UseWordle;