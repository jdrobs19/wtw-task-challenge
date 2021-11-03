import React, { Component } from 'react';
import './TaskBoard.css';

export class UpdateTask extends Component {
    static displayName = UpdateTask.name;

    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            tasks: [],
            message: ''
        };
    }

    componentDidMount() {
        fetch("https://localhost:44302/tasks/ " + this.props.match.params.id)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        tasks: result
                    });
                },

                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }

    updateTask = () => {
        let task = {
            Id: this.refs.Id.value,
            Title: this.refs.Title.value,
            Description: this.refs.Description.value,
            Status: this.refs.Status.value,
            Priority: this.refs.Priority.value,
            Due: this.refs.Due.value
        };

        fetch("https://localhost:44302/tasks/" + task.Id, {
            method: 'PUT',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(task)
        }).then(response => response.json())
    }

    deleteTask = () => {
        let task = {
            Id: this.refs.Id.value,
        };

        fetch("https://localhost:44302/tasks/" + task.Id, {
            method: 'DELETE',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(task)
        }).then(response => response.json())
    }

    render() {

        const { error, isLoaded, tasks } = this.state;

        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return (

<div  id="task-form-modal" tabindex="-1" role="dialog" aria-labelledby="task-form-modal"
                    aria-hidden="true">
                    <div className="modal-dialog modal-dialog-centered" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title" id="task-form-modal">Update Task</h5>
                            </div>
                            <div className="modal-body">
                                <form>
                                <div className="form-group">
                                <div className="form-group">
                                        <label for="modalTaskDescription">Task ID</label>
                                        <input id="modalTaskDescription" rows="1" className="form-control" value={tasks.id} ref="Id"></input>
                                    </div>
                                        <label for="modalTaskTitle">Task Title</label>
                                        <input type="text" id="modalTaskTitle" rows="1" className="form-control" defaultValue={tasks.title} ref="Title"></input>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalTaskDescription" >Task description</label>
                                        <textarea id="modalTaskDescription" rows="3" className="form-control" defaultValue={tasks.description} ref="Description"></textarea>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalTaskPriority" >Task Priority</label>
                                        <select id="modalTaskPriority" className="form-control" defaultValue={tasks.priority} ref="Priority">
                                            <option>High</option>
                                            <option>Medium</option>
                                            <option>Low</option>
                                        </select>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalTaskStatus" >Task Status</label>
                                        <select id="modalTaskStatus" className="form-control" defaultValue={tasks.status} ref="Status">
                                            <option>Not Started</option>
                                            <option>Started</option>
                                            <option>Complete</option>
                                        </select>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalDueDate">Due date</label>
                                        <input type="text" className="form-control" id="modalDueDate" placeholder="mm/dd/yyyy" autocomplete="off" defaultValue={tasks.due} ref="Due"/>
                                    </div>
                                </form>
                            </div>
                            <div className="modal-footer">
                                <a type="button" className="btn btn-close" data-dismiss="modal" href="/">Close</a>
                                <button type="button" className="btn btn-delete" onClick={this.deleteTask}>Delete</button>
                                <button type="button" className="btn btn-save" onClick={this.updateTask}>Update Task</button>
                            </div>
                        </div>
                    </div>
                </div>
                
        );
    }
}
}