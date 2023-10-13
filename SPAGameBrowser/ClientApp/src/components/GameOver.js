import React, { useContext } from 'react';
import { gameContext } from "./GamePage"

const GameOver = () => {
    const {
        gameOver,
        currAttempt,
        correctWord } = useContext(gameContext);
    return (
        <div className="gameOver">
            <h3>
                {gameOver.guessedWord ? "Congratulations! You've won." : "Oops! You lost. Game over"}
            </h3>
            <h1>Correct word: {correctWord}</h1>
            {gameOver.guessedWord && (<h3>You've guessed in {currAttempt.attempt} attempts.</h3>) }
        </div>
    );
}

export default GameOver;