import React, { useState, useEffect } from 'react';
import Board from './Board';
import Keyboard from './Keyboard';
import { createContext } from "react";
import { boardDefault, getWord } from './Words';
import '../custom.css';
import GameOver from './GameOver';

export const gameContext = createContext();

const GamePage = () => {
    const [board, setBoard] = useState(boardDefault);

    const [currAttempt, setCurrAttempt] = useState({
        attempt: 0,
        letterPosition: 0
    });

    const [wordSet, setWordSet] = useState(new Set());
    const [disableLetter, setDisableLetter] = useState([]);
    const [correctWord, setCorrectWord] = useState("");

    const [gameOver, setGameOver] = useState({
        gameOver: false,
        guessedWord: false
    });

    useEffect(() => {
        getWord().then((words) => {
            //console.log(words)
            setWordSet(words.wordSet);
            setCorrectWord(words.selectedWord);
        })
    }, [])

    console.log(correctWord);

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

        if (currWord.toLowerCase() === correctWord) {
            setGameOver({ gameOver: true, guessedWord: true })
            return;
        }

        if (currAttempt.attempt >= 4) {
            setGameOver({gameOver: true, guessedWord: false})
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
                setDisableLetter,
                gameOver,
                setGameOver
            }}>
                <div className="game">
                <Board />
                    {gameOver.gameOver ? <GameOver /> : <Keyboard />}
                </div>
            </gameContext.Provider>

        </div>
    );
};

export default GamePage;