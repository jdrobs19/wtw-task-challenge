import React, { Component } from 'react';

export class SingleTask extends Component {
    static displayName = SingleTask.name;

    render() {
        return (

            <div>
                <li className="list-group-item">
                    <h5>Task title</h5>
                    <p>Task description</p>
                    <p>Task priority</p>
                    <p>Status</p>
                    <p>Due</p>
                </li>
            </div>
        );
    }
}