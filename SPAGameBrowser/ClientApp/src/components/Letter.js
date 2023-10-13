import React, { useContext, useEffect } from 'react';
import { gameContext } from "./GamePage";
import '../custom.css';

const Letter = ({ letterPosition, attemptValue }) => {
    const {
        board,
        correctWord,
        currAttempt,
        setDisableLetter } = useContext(gameContext);

    const letter = board[attemptValue][letterPosition];

    const correctLetter = correctWord.toUpperCase()[letterPosition] === letter;

    const almostLetter = !correctLetter && letter !== ""
        && correctWord.toUpperCase().includes(letter);

    const letterState = currAttempt.attempt > attemptValue &&
        (correctLetter ? "correct" : almostLetter ? "almost" : "error");

    useEffect(() => {
        if (letter !== "" && !correctLetter && !almostLetter) {
            setDisableLetter((prev) => [...prev, letter])
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [currAttempt.attempt]);


    return (
        <div className="letter" id={letterState}>
            { letter }
        </div>
    );
}

export default Letter;