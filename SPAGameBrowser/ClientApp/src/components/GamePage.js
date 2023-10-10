import React, { useState } from 'react';
import Board from './Board';
import Keyboard from './Keyboard';
import { createContext } from "react";
import { boardDefault } from './Words';
import '../custom.css';

export const gameContext = createContext();

const GamePage = () => {
    const [board, setBoard] = useState(boardDefault);
    //console.log('board:', board);
    const [currAttempt, setCurrAttempt] = useState({ attempt: 0, letterPos: 0 });

    const onSelectLetter = (keyVal) => {
        if (currAttempt.letterPos > 4) return;

        const newBoard = [...board];
        newBoard[currAttempt.attempt][currAttempt.letterPos] = keyVal;
        setBoard(newBoard);
        setCurrAttempt({ ...currAttempt, letterPos: currAttempt.letterPos + 1 });
    }

    const onDelete = () => {
        if (currAttempt.letterPos === 0) return;

        const newBoard = [...board];
        newBoard[currAttempt.attempt][currAttempt.letterPos - 1] = "";
        setBoard(newBoard);
        setCurrAttempt({ ...currAttempt, letterPos: currAttempt.letterPos - 1 })
    }

    const onEnter = () => {
        if (currAttempt.letterPos !== 5) return;

        setCurrAttempt({ attempt: currAttempt.attempt + 1, letterPos: 0 })
    }

    return (
        <div>
            <h1>Wordle Clone</h1>
            <p>Coming soon</p>

            <gameContext.Provider value={{
                board,
                setBoard,
                currAttempt,
                setCurrAttempt,
                onSelectLetter,
                onDelete,
                onEnter
            }}>
                <div className="game">
                <Board />
                <Keyboard />
                </div>
            </gameContext.Provider>

        </div>
    );
};

export default GamePage;