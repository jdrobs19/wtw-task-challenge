import React, {Component} from 'react';

export class SingleTask extends Component {
    static displayName = SingleTask.name;

    constructor() {
        super();
        this.state = {
            tasks: [],
            loading: true
        };
    }

    componentDidMount() {
        this.populateTaskData();
    }

    render() {
        return (

            <div className="card">
                <li>
                    <h3>{this.props.task.Title}</h3>
                    <p>{this.props.task.Description}</p>
                    <p>{this.props.task.Priority}</p>
                    <p>{this.props.task.Status}</p>
                    <p>{this.props.task.Due}</p>
                </li>
            </div>
        );
    }
}