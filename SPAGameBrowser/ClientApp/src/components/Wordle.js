import { useEffect } from 'react';
import Grid from './Grid';
import Keyboard from './Keyboard';
import useWordle from './hooks/useWordle';

const Wordle = ({ solution }) => {
    const { currentGuess, guesses, turn, isCorrect, usedKeys, handleKeyup } = useWordle(solution)

    useEffect(() => {
        window.addEventListener('keyup', handleKeyup)

        if (isCorrect) {
            console.log('congrats, you win')
            window.removeEventListener('keyup', handleKeyup)
        }
        if (turn > 5) {
            console.log('unlucky, out of guesses')
            window.removeEventListener('keyup', handleKeyup)
        }

        return () => window.removeEventListener('keyup', handleKeyup)
    }, [handleKeyup, isCorrect, turn])

    return (
        <div>
            <div className="solution">solution - {solution}</div>
            <Grid guesses={guesses} currentGuess={currentGuess} turn={turn} />
            <Keyboard usedKeys={usedKeys} />
        </div>
    )
};

export default Wordle;