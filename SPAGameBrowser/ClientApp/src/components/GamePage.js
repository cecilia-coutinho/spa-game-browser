import { useEffect, useState } from 'react';
import { getWord } from './UseFetch/GetWord';
import Wordle from './Wordle';

const GamePage = ({ setShowModal }) => {
    const [solution, setSolution] = useState(null)

    const fetchData = () => {
        getWord()
            .then(getWord => {
                const randomSolution = getWord[Math.floor(Math.random() * getWord.length)];
                setSolution(randomSolution.wordName);
            });
    };

    useEffect(() => {
        fetchData();
    }, []);

    console.log('solution: ', solution);

    return (
        <div className="game">
            <h1>Wordle Clone</h1>
            {solution && <Wordle solution={solution} fetchData={fetchData} setShowModal={setShowModal} />}
        </div>
    );
};

export default GamePage;