import React, { useState } from 'react';
import Board from './Board';
import Keyboard from './Keyboard';
import { createContext } from "react";
import { boardDefault } from './Words';
import '../custom.css';

export const gameContext = createContext();

const GamePage = () => {
    const [board, setBoard] = useState(boardDefault);
    console.log('board:', board);

    const [currAttempt, setCurrAttempt] = useState({attempt: 0, letterPos: 0});

    return (
        <div>
            <h1>Wordle Clone</h1>
            <p>Coming soon</p>

            <gameContext.Provider value={{ board, setBoard, currAttempt, setCurrAttempt }}>
                <div className="game">
                <Board />
                <Keyboard />
                </div>
            </gameContext.Provider>

        </div>
    );
};

export default GamePage;