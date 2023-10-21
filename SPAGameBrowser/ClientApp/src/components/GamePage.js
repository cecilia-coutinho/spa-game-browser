import { useEffect, useId, useState } from 'react';
//import { getWord } from './UseFetch/GetWord';
import Wordle from './Wordle';
import authService from './api-authorization/AuthorizeService';
import useFetch from './UseFetch/useFetch';

const GamePage = ({ setShowModal }) => {

    const [token, setToken] = useState(null);
    const [solution, setSolution] = useState(null);
    const [solutionId, setSolutionId] = useState(null);
    const { data: getWord } = useFetch('api/Words', token);

    useEffect(() => {
        authService.getAccessToken()
            .then(tokenValue => {
                setToken(tokenValue);
            })
            .catch(error => {
                console.error('Error getting access token:', error.message);
            });
    }, []);

    const fetchSolution = async () => { 
        if (getWord && getWord.length > 0) {
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
        }

    };

    useEffect(() => {
            fetchSolution();
    }, [getWord]);

    console.log('solution: ', solution);

    return (
        <div className="game">
            <h1>Wordle Clone</h1>
            {solution &&
                <Wordle
                    solution={solution}
                    solutionId={solutionId}
                    fetchSolution={fetchSolution}
                    setShowModal={setShowModal}
                />}
        </div>
    );
};

export default GamePage;