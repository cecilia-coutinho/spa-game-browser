import React, { Component } from 'react';
import { Letter } from './Letter';
import { boardDefault } from './Words'; 
import '../custom.css';

export class Board extends Component {
    static displayName = Board.name;

    constructor(props) {
        super(props);
        this.state = {
            board: boardDefault
        };
    }

    render() {
        return (
            <div className="board">
                Board
                <div className="row">
                    <Letter letterPosition={0} attemptValue={0} />
                    <Letter letterPosition={1} attemptValue={0} />
                    <Letter letterPosition={2} attemptValue={0} />
                    <Letter letterPosition={3} attemptValue={0} />
                    <Letter letterPosition={4} attemptValue={0} />
                </div>
                <div className="row">
                    <Letter letterPosition={0} attemptValue={1} />
                    <Letter letterPosition={1} attemptValue={1} />
                    <Letter letterPosition={2} attemptValue={1} />
                    <Letter letterPosition={3} attemptValue={1} />
                    <Letter letterPosition={4} attemptValue={1} />
                </div>
                <div className="row">
                    <Letter letterPosition={0} attemptValue={2} />
                    <Letter letterPosition={1} attemptValue={2} />
                    <Letter letterPosition={2} attemptValue={2} />
                    <Letter letterPosition={3} attemptValue={2} />
                    <Letter letterPosition={4} attemptValue={2} />
                </div>
                <div className="row">
                    <Letter letterPosition={0} attemptValue={3} />
                    <Letter letterPosition={1} attemptValue={3} />
                    <Letter letterPosition={2} attemptValue={3} />
                    <Letter letterPosition={3} attemptValue={3} />
                    <Letter letterPosition={4} attemptValue={3} />
                </div>
                <div className="row">
                    <Letter letterPosition={0} attemptValue={4} />
                    <Letter letterPosition={1} attemptValue={4} />
                    <Letter letterPosition={2} attemptValue={4} />
                    <Letter letterPosition={3} attemptValue={4} />
                    <Letter letterPosition={4} attemptValue={4} />
                </div>
            </div>
        );
    }
}