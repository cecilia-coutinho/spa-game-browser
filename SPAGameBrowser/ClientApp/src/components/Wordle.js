import React, { useEffect, useState } from 'react';
import Grid from './Grid';
import Keyboard from './Keyboard';
import useWordle from './hooks/useWordle';
import GameOver from './GameOver';

const Wordle = ({ solution, fetchData }) => {
    const {
        currentGuess,
        guesses,
        turn,
        isCorrect,
        usedKeys,
        handleKeyup,
        handlePlayAgain,
        showModal,
        setShowModal, } = useWordle({ solution, fetchData })

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

    return (
        <div>
            <Grid guesses={guesses} currentGuess={currentGuess} turn={turn} />
            <Keyboard usedKeys={usedKeys} handleKeyup={  handleKeyup } />
            {showModal && <GameOver isCorrect={isCorrect} turn={turn} solution={solution} handlePlayAgain={handlePlayAgain} />}
        </div>
    )
};

export default Wordle;