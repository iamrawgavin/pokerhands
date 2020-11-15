import React, { Component } from 'react';

export class Poker extends Component {
    constructor(props) {
        super(props);
        this.state = {
            PlayerOneBestHand: {},
            PlayerTwoBestHand: {},
            Winner: '',
            PlayerOneCards: [],
            PlayerTwoCards: []
        };
    }

    async componentDidMount() {
        fetch('api/pokerengine')
            .then((response) => response.json())
            .then(
                (data) => {
                    const { PlayerOneBestHand, PlayerTwoBestHand, Winner, PlayerOneCards, PlayerTwoCards } = data;
                    this.setState({ PlayerOneBestHand, PlayerTwoBestHand, Winner, PlayerOneCards, PlayerTwoCards })
                }
            );
    }

    render() {
        const { PlayerOneBestHand, PlayerTwoBestHand, Winner, PlayerOneCards, PlayerTwoCards } = this.state;
        return (
        <div>

            <h1>Welcome to the Poker Game</h1>
            <h2>Winner was...drum roll... {Winner}</h2>

            <h3>Player 1's cards</h3>
            <ul>
                    {PlayerOneCards.map((item, i) => <li>{item.Rank} of {item.Suit} </li> 
                    )}
            </ul>
                Result: <b>{PlayerOneBestHand.Winner} with a high card of {PlayerOneBestHand.Rank}</b>

            <h3>Player 2's cards</h3>
            <ul>
                    {PlayerTwoCards.map((item, i) => <li>{item.Rank} of {item.Suit} </li>
                    )}
             </ul>
                Result: <b>{PlayerTwoBestHand.Winner} with a high card of {PlayerTwoBestHand.Rank}</b>

            <p>Refresh page to play again...</p>
        </div>
        )
    }

}