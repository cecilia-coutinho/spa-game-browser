import React, { useEffect, useState } from 'react';
import Grid from './Grid';
import Keyboard from './Keyboard';
import useWordle from './hooks/useWordle';
import GameOver from './GameOver';
import authService from './api-authorization/AuthorizeService';

const Wordle = ({ solution, solutionId, fetchData }) => {
    const {
        currentGuess,
        guesses,
        turn,
        isCorrect,
        usedKeys,
        handleKeyup,
        handlePlayAgain,
        showModal,
        setShowModal, } = useWordle({ solution, fetchData, solutionId })

    const [fkUserId, setFkUserId] = useState(null);

    useEffect(() => {
        const getUser = async () => {
            const user = await authService.getUser();
            setFkUserId(user.userId);
        };
        getUser();
    }, []);

    const userScore = {
        FkUserId: fkUserId,
        FkWordId: solutionId,
        Attempts: turn,
        IsGuessed: isCorrect,
        Started_At: localStorage.getItem('startedAt'),
        Finished_At: localStorage.getItem('finishedAt'),
    };

    console.log(userScore);


    useEffect(() => {
        window.addEventListener('keyup', handleKeyup)

        if (isCorrect) {
            setTimeout(() => setShowModal(true), 1000)
            window.removeEventListener('keyup', handleKeyup)
        }
        if (turn > 5) {
            setTimeout(() => setShowModal(true), 1000)
            window.removeEventListener('keyup', handleKeyup)
        }

        return () => window.removeEventListener('keyup', handleKeyup)
    }, [handleKeyup, isCorrect, turn])


    const handlePostScore = async (userScore) => {
        
        const response = await fetch('/api/UserScore', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userScore),
        });

        if (response.ok) {
            return await response.json();
        } else {
            throw new Error(`Failed to fetch user score: ${response.statusText}`);
        }
    };



    return (
            <div>
                <Grid guesses={guesses} currentGuess={currentGuess} turn={turn} />
                <Keyboard usedKeys={usedKeys} handleKeyup={handleKeyup} />
                {showModal &&
                    <GameOver
                        isCorrect={isCorrect}
                        turn={turn}
                        solution={solution}
                        handlePlayAgain={handlePlayAgain}
                        handlePostScore={handlePostScore}
                    />}
            </div>
        )
    };

    export default Wordle;