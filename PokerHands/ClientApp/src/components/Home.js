import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, iTrellis Recruiting!</h1>
            <p>
                The project I selected was Poker Hands. The solution I created has 3 projects within it.
                <ul>
                    <li>PokerEngine - class library that handles things like dealing a hand and determining winner of game</li>
                    <li>PokerEngineTests - suite of tests to exercise the core logic of the application</li>
                    <li>PokerHands - the web facing portion of the project (created by selecting new project > React.js template</li>
                </ul>
                This code was developed on a Mac with the community edition of Visual Studio 2019.
            </p>
      </div>
    );
  }
}
