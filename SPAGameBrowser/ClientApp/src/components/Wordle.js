import React, { useEffect, useState } from 'react';
import Grid from './Grid';
import Keyboard from './Keyboard';
import useWordle from './hooks/useWordle';
import GameOver from './GameOver';
import axios from 'axios';
import authService from './api-authorization/AuthorizeService';

const Wordle = ({ solution, solutionId, fetchSolution }) => {
    const [hasPostedScore, setHasPostedScore] = useState(false);

    const {
        currentGuess,
        guesses,
        turn,
        isCorrect,
        usedKeys,
        handleKeyup,
        handlePlayAgain,
        showModal,
        setShowModal, } = useWordle({ solution, fetchSolution, solutionId, setHasPostedScore })


    useEffect(() => {
        window.addEventListener('keyup', handleKeyup)

        if (isCorrect || turn > 5) {
            setTimeout(() => setShowModal(true), 1000)

            if (!hasPostedScore) {
                handlePostScore();
                setHasPostedScore(true);
            }

            window.removeEventListener('keyup', handleKeyup)
        }

        return () => window.removeEventListener('keyup', handleKeyup)
    }, [handleKeyup, isCorrect, turn])

    const handlePostScore = () => {
        const finishedAt = (new Date()).toISOString().slice(0, 19).replace(/-/g, "/").replace("T", " ");

        authService.getAccessToken()
        .then(token => {
            return axios.post('/api/UserScore', {
                FkWordId: solutionId,
                Attempts: turn,
                IsGuessed: isCorrect,
                Started_At: localStorage.getItem('startedAt'),
                Finished_At: finishedAt
            }, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
        })
        .then(function (response) {
            //console.log('response: ', response);
        })
        .catch(function (error) {
            //console.log(error)
            //console.error('Error while posting:', error.message);
            throw new Error(`Failed to fetch: ${error.message}`);
        });
    }

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
                />}
        </div>
    )
};

export default Wordle;