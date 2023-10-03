import React, { Component } from 'react';

export class Profile extends Component {
    static displayName = Profile.name;


    render() {

        return (
            <div>
                <h1>Profile</h1>
                <p>This component demonstrates fetching profile.</p>
            </div>
        );
    }
}