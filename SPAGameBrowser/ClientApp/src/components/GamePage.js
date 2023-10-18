import { useEffect, useState } from 'react';
import { getWord } from './UseFetch/GetWord';
import Wordle from './Wordle';

const GamePage = ({ setShowModal }) => {
    const [solution, setSolution] = useState(null);
    const [solutionId, setSolutionId] = useState(null);

    const fetchData = async () => {
        getWord()
            .then(getWord => {
                const randomSolution = getWord[Math.floor(Math.random() * getWord.length)];
                const storedSolution = localStorage.getItem('wordleSolution');
                const storedSolutionId = localStorage.getItem('wordleSolutionId');

                if (storedSolution) {
                    setSolution(storedSolution);
                    setSolutionId(storedSolutionId);
                } else {
                    setSolution(randomSolution.wordName);
                    setSolutionId(randomSolution.wordId);
                    localStorage.setItem('wordleSolution', randomSolution.wordName);
                    localStorage.setItem('wordleSolutionId', randomSolution.wordId);

                    const startedAt = (new Date()).toISOString().slice(0, 19).replace(/-/g, "/").replace("T", " ");
                    localStorage.setItem('startedAt', startedAt)
                }
            });
    };

    useEffect(() => {
        fetchData();
    }, []);


    console.log('solution: ', solution);

    return (
        <div className="game">
            <h1>Wordle Clone</h1>
            {solution &&
                <Wordle
                    solution={solution}
                    solutionId={solutionId}
                    fetchData={fetchData}
                    setShowModal={setShowModal}
                />}
        </div>
    );
};

export default GamePage;