import React, { Component } from 'react';
import { Board } from './Board';
import { Keyboard } from './Keyboard';

export class GamePage extends Component {
    static displayName = GamePage.name;

    render() {
        return (
            <div>
                <h1>Wordle Clone</h1>
                <p>Coming soon</p>
                <Board />
                <Keyboard />
            </div>
        );
    }
}