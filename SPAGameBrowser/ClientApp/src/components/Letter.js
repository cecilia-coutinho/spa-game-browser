import React, { Component } from 'react';
import '../custom.css';

export class Letter extends Component {
    static displayName = Letter.name;

    render() {
        const { letterPosition, attemptValue } = this.props;

        return (
            <div className="Letter">
                Letter
            </div>
        );
    }
}