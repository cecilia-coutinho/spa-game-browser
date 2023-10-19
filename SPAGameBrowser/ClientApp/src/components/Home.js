import React, { Component } from 'react';
import { Login } from './api-authorization/Login';
import authService from './api-authorization/AuthorizeService';
import '../custom.css';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);

        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name
        });
    }

    render() {
        const { isAuthenticated, userName } = this.state;
        let playButton;

        if (!isAuthenticated) {
            playButton = <a className="button" href="/authentication/login">Play now</a>;
        } else {
            playButton = <a className="button" href="/game">Play now</a>;
        }

        return (
          <div className="homeContainer">
            <h1>Wordle Clone</h1>
            <h3>Welcome to Wordle Clone!</h3>
            <div className="instructions">
              <h4>Instructions:</h4>
              <div className="centered-content">
                <p><strong>Objective:</strong> Guess the hidden five-letter word.</p>
                <p><strong>Guesses:</strong> You have 6 attempts to guess the word.</p>
                <p><strong>Letters:</strong> Type a five-letter word guess and hit "Enter".</p>
                <div>
                  <p><strong>Feedback:</strong> After each guess, you'll receive feedback:</p>
                  <div className="feedback">
                    <p><span style={{ color: '#528d4e', fontWeight: 'bold' }}>Correct letter and position:</span> Indicated by a green square.</p>
                    <p><span style={{ color: '#b49f39', fontWeight: 'bold' }}>Correct letter, wrong position:</span> Indicated by an yellow square.</p>
                    <p><span style={{ color: '#34495E', fontWeight: 'bold' }}>Incorrect letter:</span> Indicated by a dark square.</p>
                  </div>
                </div>
                <p><strong>Play again:</strong> To start a new game, click "Play Again".</p>
              </div>
            </div>

            <div className="rules">
              <h4>Game Rules:</h4>
              <div className="centered-content">
                <p>- Words must be five letters long.</p>
                <p>- Only valid English words are allowed.</p>
              </div>
            </div>

            <div className="tips">
              <h4>Tips:</h4>
              <div className="centered-content">
                <p>- Use the feedback to refine your guesses.</p>
                <p>- Pay attention to common English letter combinations.</p>
                <p>- Have fun and challenge yourself!</p>
              </div>
            </div>
            {playButton}
          </div>
        );

    }
}
