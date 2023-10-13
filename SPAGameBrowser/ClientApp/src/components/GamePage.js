import { useEffect, useState } from 'react'
import { getWord } from './UseFetch/GetWord';

const GamePage = () => {
    const [solution, setSolution] = useState(null)

    useEffect(() => {
        getWord()
            .then(getWord => {
                const randomSolution = getWord[Math.floor(Math.random() * getWord.length)]
                setSolution(randomSolution.wordName)
            })
    }, [setSolution])

    return (
        <div className="App">
            <h1>Wordle</h1>
            {solution && <div>Solution is: {solution}</div>}
        </div>
    )
};

export default GamePage;