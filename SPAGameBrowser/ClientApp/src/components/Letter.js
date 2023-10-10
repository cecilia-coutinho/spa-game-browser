import React, { useContext } from 'react';
import { gameContext } from "./GamePage";
import '../custom.css';

const Letter = ({ letterPosition, attemptValue }) => {

    console.log('letterPosition:', letterPosition);
    console.log('attemptValue:', attemptValue);


    const { board } = useContext(gameContext);
    const letter = board[attemptValue][letterPosition]

    return (
        <div className="letter">
            { letter }
        </div>
    );
}

export default Letter;