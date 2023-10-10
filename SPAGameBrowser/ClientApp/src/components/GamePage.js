import React, { useState } from 'react';
import Board from './Board';
import Keyboard from './Keyboard';
import { createContext } from "react";
import { boardDefault } from './Words';
import '../custom.css';

export const GameContext = createContext();

const GamePage = () => {
    const [board, setBoard] = useState(boardDefault);

    return (
        <div>
            <h1>Wordle Clone</h1>
            <p>Coming soon</p>

            <GameContext.Provider value={{ board, setBoard }}>
                <Board />
                <Keyboard />
            </GameContext.Provider>

        </div>
    );
};

export default GamePage;