import React, { useState, useEffect } from 'react';
import Board from './Board';
import Keyboard from './Keyboard';
import { createContext } from "react";
import { boardDefault, getWord } from './Words';
import '../custom.css';

export const gameContext = createContext();

const GamePage = ({ userId }) => {
    const [board, setBoard] = useState(boardDefault);
    //console.log('board:', board);
    const [currAttempt, setCurrAttempt] = useState({ attempt: 0, letterPosition: 0 });
    const [wordSet, setWordSet] = useState(new Set());
    const [disableLetter, setDisableLetter] = useState([]);

    //TO DELETE: temp variable for test purposes
    const correctWord = "OCEAN" 
    useEffect(() => {
        getWord().then((words) => {
            //console.log(words)
            setWordSet(words.wordSet)
        })
    }, [])

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

        let currWord = "";
        for (let i = 0; i < 5; i++) {
            currWord += board[currAttempt.attempt][i];
        }

        setCurrAttempt({ attempt: currAttempt.attempt + 1, letterPosition: 0 })

        if (!wordSet.has(currWord.toLowerCase())) {
            alert("Incorrect!");
        }

        if (currWord === correctWord) {
            alert("Congratulations! You've won.")
            //"Oops! You lost. Game over".
            return;
        }
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
                correctWord,
                disableLetter,
                setDisableLetter
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