import React, { Component } from 'react';

export class UserBoard extends Component {
    static displayName = UserBoard.name;


    render() {

        return (
            <div>
                <h1>Profile</h1>
                <p>This component demonstrates fetching profile.</p>
            </div>
        );
    }
}