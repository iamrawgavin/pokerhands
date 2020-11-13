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
            <p>
                Please note, the <b>React</b> portion of the application is incomplete. It has been a while since I worked with it and did not want to spend too much time trying to thread the needle.
                Basically, I ran into issues related to rendering the contents of the API call. Using the React Developer Tools in Firefox, I was able to confirm that the call was successful,
                and I also display the winner of the game which was just a root-level string. I need to review how to render the child objects and child arrays, too. The API works fine, and assuming you
                have not edited the launchSettings.json file and are running locally can be called <a target="_blank" href="https://localhost:32330/api/pokerengine">here</a>. It runs a new game each GET request.
            </p>
      </div>
    );
  }
}
