import { useEffect, useState } from 'react';
import { getWord } from './UseFetch/GetWord';
import Wordle from './Wordle';

const GamePage = () => {
    const [solution, setSolution] = useState(null)

    useEffect(() => {
        getWord()
            .then(getWord => {
                const randomSolution = getWord[Math.floor(Math.random() * getWord.length)]
                setSolution(randomSolution.wordName)
            })
    }, [setSolution])

    console.log('solution: ', solution);

    return (
        <div className="game">
            <h1>Wordle Clone</h1>
            {solution && <Wordle solution={ solution } />}
        </div>
    );
};

export default GamePage;