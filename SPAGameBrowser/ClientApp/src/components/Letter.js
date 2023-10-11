import React, { useContext } from 'react';
import { gameContext } from "./GamePage";
import '../custom.css';

const Letter = ({ letterPosition, attemptValue }) => {
    //console.log('letterPosition:', letterPosition);
    //console.log('attemptValue:', attemptValue);
    const { board, correctWord, currAttempt } = useContext(gameContext);
    const letter = board[attemptValue][letterPosition];

    const correctLetter = correctWord.toUpperCase()[letterPosition] === letter;

    const almostLetter = !correctLetter && letter !== ""
        && correctWord.toUpperCase().includes(letter);

    const letterState = currAttempt.attempt > attemptValue &&
        (correctLetter ? "correct" : almostLetter ? "almost" : "error");


    return (
        <div className="letter" id={letterState}>
            { letter }
        </div>
    );
}

export default Letter;