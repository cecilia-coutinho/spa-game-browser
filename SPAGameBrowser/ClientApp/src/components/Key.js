import React, { useContext } from 'react';
import { gameContext } from "./GamePage"

const Key = ({ keyVal, bigKey, disabled }) => {
    const {
        onSelectLetter,
        onDelete,
        onEnter } = useContext(gameContext);

    const selectLetter = () => {
        if (keyVal === "ENTER")
        {
            onEnter()
        }
        else if (keyVal === "DELETE")
        {
            onDelete()
        }
        else
        {
            onSelectLetter(keyVal)
        }
    }

    return (
        <div className="key" id={bigKey ? "big": disabled && "disabled"} onClick={selectLetter}>
            {keyVal}
        </div>
    );
}

export default Key;