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
    const [currAttempt, setCurrAttempt] = useState({ attempt: 0, letterPosition: 0 });

    //TO DELETE: temp variable for test purposes
    const correctWord = "OCEAN" 

    const onSelectLetter = (keyVal) => {
        if (currAttempt.letterPosition > 4) return;

        const newBoard = [...board];
        newBoard[currAttempt.attempt][currAttempt.letterPosition] = keyVal;
        setBoard(newBoard);
        setCurrAttempt({ ...currAttempt, letterPosition: currAttempt.letterPosition + 1 });
    }

    const onDelete = () => {
        if (currAttempt.letterPosition === 0) return;

        const newBoard = [...board];
        newBoard[currAttempt.attempt][currAttempt.letterPosition - 1] = "";
        setBoard(newBoard);
        setCurrAttempt({ ...currAttempt, letterPosition: currAttempt.letterPosition - 1 })
    }

    const onEnter = () => {
        if (currAttempt.letterPosition !== 5) return;

        setCurrAttempt({ attempt: currAttempt.attempt + 1, letterPosition: 0 })
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
                onEnter,
                correctWord
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