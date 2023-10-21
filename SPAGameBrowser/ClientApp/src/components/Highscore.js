import React, { useState, useEffect } from 'react';
import authService from './api-authorization/AuthorizeService';
import useFetch from './UseFetch/useFetch';

const Highscore = () => {
    const [token, setToken] = useState(null);
    const { data: userStatistics } = useFetch('api/UserScore', token);
    const { data: dailyScores } = useFetch('api/UserScore/Daily');
    const { data: historyScores } = useFetch('api/UserScore/History');

    useEffect(() => {
        authService.getAccessToken()
            .then(tokenValue => {
                setToken(tokenValue);
            })
            .catch(error => {
                console.error('Error getting access token:', error.message);
            });
    }, []);
    return (
        <div className="flex-container">
            {userStatistics && (
                <React.Fragment>
                    <h4 className="label">Hi {userStatistics.name}!</h4>
                    <div className="score-container">
                        <h5>Your Statistics:</h5>
                        <div className="label">Games Played: {userStatistics.totalGamesPlayed}</div>
                        <div className="label">Wins: {userStatistics.totalGamesWon}</div>
                        <div className="label">Winning Rate: {userStatistics.winningPercentage} %</div>
                        <div className="label">Avg. Guesses/Game: {userStatistics.averageGuessesPerGame}</div>
                    </div>
                </React.Fragment>
            )}
            <div className="leaderboard">

                {dailyScores && (
                    <React.Fragment>
                        <div className="score-container">
                            <h3>Daily HighScore Leaders:</h3>
                            {dailyScores.map((dscore, index) => (
                                <div key={index}>
                                    <p>{dscore.name.toUpperCase()}: {dscore.totalGamesWon} Victories.</p>
                                </div>
                            ))}
                        </div>
                    </React.Fragment>
                )}

                {historyScores && (
                    <React.Fragment>
                        <div className="score-container">
                            <h3>Top 10 Players of All Time</h3>
                            {historyScores.map((hscore, index) => (
                                <div key={index}>
                                    <p>{hscore.name.toUpperCase()}: {hscore.totalGamesWon} Victories.</p>
                                </div>
                            ))}
                        </div>
                    </React.Fragment>
                )}

            </div>

        </div>
    );

};

export default Highscore;
