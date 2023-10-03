import React, { Component } from 'react';

export class Game extends Component {
  static displayName = Game.name;

  render() {
    return (
      <div>
        <h1>Wordle Clone</h1>
        <p>Play now!!</p>
      </div>
    );
  }
}
