import React, { Component, useState } from 'react';
import ReactDOM from 'react-dom';
import './TaskBoard.css';

export class AddTask extends Component {
    static displayName = AddTask.name;

    //POST request to create a new task
    constructor(props) {
        super(props);
        this.state = {
            message: ''
        };
    }

    createTask = () => {
        let task = {
            Title: this.refs.Title.value,
            Description: this.refs.Description.value,
            Status: this.refs.Status.value,
            Priority: this.refs.Priority.value,
            Due: this.refs.Due.value
        };

        fetch("https://localhost:44302/tasks", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(task)
        }).then(response => response.json()).then(response => {
            if (response) {
                this.setState({
                    message: 'Task created successfully'
                });
            }
        });
    }


    render() {
        return (

            <div id="task-form-modal" tabindex="-1" role="dialog" aria-labelledby="task-form-modal"
                aria-hidden="true">
                <div className="modal-dialog modal-dialog-centered" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="task-form-modal">Add New Task</h5>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="form-group">
                                    <label for="modalTaskTitle">Task Title</label>
                                    <input type="text" id="modalTaskTitle" rows="1" className="form-control" ref="Title"></input>
                                </div>
                                <div className="form-group">
                                    <label for="modalTaskDescription">Task description</label>
                                    <textarea id="modalTaskDescription" rows="3" className="form-control" ref="Description"></textarea>
                                </div>
                                <div className="form-group">
                                    <label for="modalTaskStatus" >Task Status</label>
                                    <select id="modalTaskStatus" className="form-control" disabled="true" ref="Status">
                                        <option>Not Started</option>
                                        <option>Started</option>
                                        <option>Complete</option>
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label for="modalTaskPriority">Task Priority</label>
                                    <select id="modalTaskPriority" className="form-control" ref="Priority">
                                        <option>Low</option>
                                        <option>Medium</option>
                                        <option>High</option>
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label for="modalDueDate">Due date</label>
                                    <input type="text" className="form-control" id="modalDueDate" placeholder="mm/dd/yyyy" autocomplete="off" ref="Due" />
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <a type="button" className="btn btn-close" data-dismiss="modal" href="/">Close</a>
                            <button type="submit" className="btn btn-save" onClick={this.createTask}>Save Task</button>
                            <p>{this.state.message}</p>
                        </div>
                    </div>
                </div>
            </div>

        );
    }
}

const element = <AddTask />;
ReactDOM.render(element, document.getElementById('root'));