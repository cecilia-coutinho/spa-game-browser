import React, { useState, useEffect } from 'react';
import axios from 'axios';
import authService from './api-authorization/AuthorizeService'

const Highscore = () => {
    const [userStatistics, setUserStatistics] = useState([]);
    const [dailyScores, setDailyScores] = useState([]);

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

    useEffect(() => {
        handleGetStatistics();
        handleGetDailyScores();
    }, []);

    return (
        <div className="flex-container">
            <h4 className="label">Hi {userStatistics.name}!</h4>
            <div className="score-container">
                <h5>Your Statistics:</h5>
                <div className="label">Total Games Played: {userStatistics.totalGamesPlayed}</div>
                <div className="label">Total Games Won: {userStatistics.totalGamesWon}</div>
                <div className="label">Winning Percentage: {userStatistics.winningPercentage} %</div>
                <div className="label">Average Guesses Per Game: {userStatistics.averageGuessesPerGame}</div>
            </div>

            <div className="score-container">
                <h3>Top 10 Daily HighScores:</h3>
                {dailyScores.map((dscore, index) => (
                    <div key={index}>
                        <p>{dscore.name.toUpperCase()}, {dscore.totalGamesWon} wons.</p>
                    </div>
                ))}
            </div>

        </div>
    );

};

export default Highscore;
