import React, { useState, useEffect } from 'react';
import axios from 'axios';
import authService from './api-authorization/AuthorizeService'

const Highscore = () => {
    const [userScores, setUserScores] = useState([]);
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
                return response.data;
            })
            .catch(error => {
                console.error('Error in GET Request:', error.message);
                throw error; // Re-throw the error to be caught by the caller
            });
    }


    //useEffect(() => {
    //    axios.get('api/UserScore')
    //        .then(response => {
    //            setUserScores(response.data);
    //        })
    //        .catch(error => {
    //            console.error('Error in GET Request:', error.message);
    //        });
    //}, []);


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
        handleGetDailyScores();
    }, []);

    const renderUserScores = (score) => {
        return handleGetStatistics()
            .then(userScores => {
                return (
                    <div>
                        <div className="label">Total Games Played: {userScores.totalGamesPlayed}</div>
                        <div className="label">Total Games Won: {userScores.totalGamesWon}</div>
                        <div className="label">Winning Percentage: {userScores.winningPercentage} %</div>
                        <div className="label">Average Guesses Per Game: {userScores.averageGuessesPerGame}</div>
                    </div>
                );
            })
            .catch(error => {
                return null;
            });
    };

    return (
        <div>
        <h4 className="label">Hi {userScores.length > 0 ? userScores[0].name : ''}!</h4>
        <div className="flex-container">
           {userScores.map((score, index) => (
                    <div key={index} className="score-container">
                        <h3>Your Statistics:</h3>
                        {renderUserScores(score)}
                    </div>
                ))}
            </div>

            <div className="score-container">
                <h3>Top 10 Daily HighScores:</h3>
                {dailyScores.map((dscore, index) => (
                        <div key={ index }>
                            <p>{dscore.name.toUpperCase()}, {dscore.totalGamesWon} points</p>
                        </div>
                ))}
            </div>

        </div>
    );

};

export default Highscore;
