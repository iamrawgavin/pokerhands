import React, { Component } from 'react';

export class Poker extends Component {
    constructor(props) {
        super(props);
        this.state = {pokergame: {}};
    }

    componentDidMount() {
        this.getPokerGame();
    }

    render() {
        return (
        <div>

        <h1>Welcome to the Poker Game</h1>
            Winner was {this.state.pokergame.Winner}
            </div>
            )
    }

    async getPokerGame() {
        const response = await fetch('api/pokerengine');
        const data = await response.json();
        this.setState({pokergame: data});
    }
}