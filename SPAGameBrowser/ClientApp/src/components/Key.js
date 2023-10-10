import React, { useContext } from 'react';
import { gameContext } from "./GamePage"

const Key = ({ keyVal, bigKey }) => {
    const { board, setBoard, currAttempt, setCurrAttempt } = useContext(gameContext);

    const selectLetter = () => {
        const newBoard = [...board];
        newBoard[currAttempt.attempt][currAttempt.letterPos] = keyVal;
        setBoard(newBoard);
        setCurrAttempt({ ...currAttempt, letterPos: currAttempt.letterPos + 1 });
    }

    return (
        <div className="key" id={bigKey && "big"} onClick={selectLetter}>
            {keyVal}
        </div>
    );
}

export default Key;