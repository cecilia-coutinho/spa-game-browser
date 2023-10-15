import React from 'react';

const GameOver = ({ isCorrect, solution, turn }) => {

    return (
        <div className="gameOver">
            {isCorrect && (
                <div>
                    <h1>Congrats! You've won.</h1>
                    <p className="solution">Word: {solution}</p>
                    <p>You've guessed in {turn} attempts.</p>
                </div>
            )}
            {!isCorrect && (
                <div>
                    <h1>Oops! You lost.</h1>
                    <p className="solution">Correct word: {solution}</p>
                    <p>Game over! Maybe next time.</p>
                </div>
            )}
        </div>
    )
}

export default GameOver;