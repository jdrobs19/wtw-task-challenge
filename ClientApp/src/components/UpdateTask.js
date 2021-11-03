import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import './TaskBoard.css';

export class UpdateTask extends Component {
    static displayName = UpdateTask.name;

    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            tasks: []
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
                                        <input id="modalTaskDescription" rows="1" className="form-control" value={tasks.id} disabled="true"></input>
                                    </div>
                                        <label for="modalTaskTitle">Task Title</label>
                                        <input type="text" id="modalTaskTitle" rows="1" className="form-control" value={tasks.title}></input>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalTaskDescription" >Task description</label>
                                        <textarea id="modalTaskDescription" rows="3" className="form-control"value={tasks.description}></textarea>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalTaskPriority" >Task Priority</label>
                                        <select id="modalTaskPriority" className="form-control" value={tasks.priority}>
                                            <option>High</option>
                                            <option>Medium</option>
                                            <option>Low</option>
                                        </select>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalTaskStatus" >Task Status</label>
                                        <select id="modalTaskStatus" className="form-control"value={tasks.status}>
                                            <option>Not Started</option>
                                            <option>Started</option>
                                            <option>Complete</option>
                                        </select>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalDueDate">Due date</label>
                                        <input type="text" className="form-control" id="modalDueDate" placeholder="mm/dd/yyyy" autocomplete="off" value={tasks.due}/>
                                    </div>
                                </form>
                            </div>
                            <div className="modal-footer">
                                <NavLink type="button" className="btn btn-close" data-dismiss="modal" tag={Link} to="/">Close</NavLink>
                                <button type="button" className="btn btn-save">Update Task</button>
                            </div>
                        </div>
                    </div>
                </div>
                
        );
    }
}
}