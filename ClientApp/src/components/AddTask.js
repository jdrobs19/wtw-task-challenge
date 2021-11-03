import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import './TaskBoard.css';

export class AddTask extends Component {
    static displayName = AddTask.name;

   

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
                                    <input type="text" id="modalTaskTitle" rows="1" className="form-control" name="title"></input>
                                </div>
                                <div className="form-group">
                                    <label for="modalTaskDescription">Task description</label>
                                    <textarea id="modalTaskDescription" rows="3" className="form-control" name="description"></textarea>
                                </div>
                                <div className="form-group">
                                    <label for="modalTaskStatus" >Task Status</label>
                                    <select id="modalTaskStatus" className="form-control" disabled="true" name="status">
                                        <option>Not Started</option>
                                        <option>Started</option>
                                        <option>Complete</option>
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label for="modalTaskPriority">Task Priority</label>
                                    <select id="modalTaskPriority" className="form-control" name="priority">
                                        <option>Low</option>
                                        <option>Medium</option>
                                        <option>High</option>
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label for="modalDueDate">Due date</label>
                                    <input type="text" className="form-control" id="modalDueDate" placeholder="mm/dd/yyyy" autocomplete="off" name="due"/>
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <NavLink type="button" className="btn btn-close" data-dismiss="modal" tag={Link} to="/">Close</NavLink>
                            <button type="submit" className="btn btn-save" onClick={() => this.submit()}>Save Task</button>
                        </div>
                    </div>
                </div>
            </div>

        );
    }
}