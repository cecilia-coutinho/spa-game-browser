﻿import React, { useContext } from 'react';
import { gameContext } from "./GamePage"

const Key = ({ keyVal, bigKey }) => {
    const { board, setBoard, currAttempt, setCurrAttempt } = useContext(gameContext);

    const selectLetter = () => {
        if (keyVal === "ENTER") {
            if (currAttempt.letterPos !== 5) return;

            setCurrAttempt({attempt: currAttempt.attempt + 1, letterPos: 0})
        }
        else
        {
            if (currAttempt.letterPos > 4) return;

            const newBoard = [...board];
            newBoard[currAttempt.attempt][currAttempt.letterPos] = keyVal;
            setBoard(newBoard);
            setCurrAttempt({ ...currAttempt, letterPos: currAttempt.letterPos + 1 });
        }
    }

    return (
        <div className="key" id={bigKey && "big"} onClick={selectLetter}>
            {keyVal}
        </div>
    );
}

export default Key;