import React, { useState, useEffect } from 'react';
import axios from 'axios';
import authService from './api-authorization/AuthorizeService'

const Highscore = () => {
    const [userStatistics, setUserStatistics] = useState([]);
    const [dailyScores, setDailyScores] = useState([]);
    const [historyScores, setHistoryScores] = useState([]);

    const handleGetStatistics = () => {
        authService.getAccessToken()
            .then(token => {
                return axios.get('api/UserScore', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
            })
            .then(response => {
                setUserStatistics(response.data);
            })
            .catch(error => {
                console.error('Error in GET Request:', error.message);
                throw error;
            });
    }

    const handleGetDailyScores = async (dscore) => {
        return axios.get('api/UserScore/Daily')
            .then(response => {
                setDailyScores(response.data);
            })
            .catch(error => {
                console.error('Error in GET Request:', error.message);
                throw error;
            });
    }

    const handleGetHistoricalScores = async (hscore) => {
        return axios.get('api/UserScore/History')
            .then(response => {
                setHistoryScores(response.data);
            })
            .catch(error => {
                console.error('Error in GET Request:', error.message);
                throw error;
            });
    }

    useEffect(() => {
        handleGetStatistics();
        handleGetDailyScores();
        handleGetHistoricalScores();
    }, []);

    return (
        <div className="flex-container">
            <h4 className="label">Hi {userStatistics.name}!</h4>
            <div className="score-container">
                <h5>Your Statistics:</h5>
                <div className="label">Games Played: {userStatistics.totalGamesPlayed}</div>
                <div className="label">Wins: {userStatistics.totalGamesWon}</div>
                <div className="label">Winning Rate: {userStatistics.winningPercentage} %</div>
                <div className="label">Avg. Guesses/Game: {userStatistics.averageGuessesPerGame}</div>
            </div>

            <div className="leaderboard">

            <div className="score-container">
                    <h3>Daily HighScore Leaders:</h3>
                {dailyScores.map((dscore, index) => (
                    <div key={index}>
                        <p>{dscore.name.toUpperCase()}: {dscore.totalGamesWon} Victories.</p>
                    </div>
                ))}
                </div>

                <div className="score-container">
                    <h3>Top 10 Players of All Time</h3>
                    {historyScores.map((hscore, index) => (
                        <div key={index}>
                            <p>{hscore.name.toUpperCase()}: {hscore.totalGamesWon} Victories.</p>
                        </div>
                    ))}
                </div>
            </div>

        </div>
    );

};

export default Highscore;
