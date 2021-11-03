import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { SingleTask } from './SingleTask';
import './TaskBoard.css';

export class Taskboard extends Component {
    static displayName = Taskboard.name;

    render() {

        return (
            <section>
                 <div class="row min-vh-100 no-gutters">
                    <header className="col-12 col-lg-3 bg-dark text-light sticky-top d-flex flex-column p-4 p-lg-3">
                        <NavLink id="create-task" className="btn btn-block btn-add" data-toggle="modal" data-target="#task-form-modal" tag={Link} to="/addtask"><span className="oi oi-plus mr-2"></span>Add
                            Task</NavLink>
                        <span className="oi oi-task display-1 text-center mb-2 d-none d-lg-block mt-auto"></span>
                    </header>
                    <main className="col-12 col-lg-9 d-flex flex-column">
                        <div className="m-5 row justify-content-around">
                           
                            <div className="col-12 col-md-6 col-xl-3 mb-3">
                                <div className="card">
                                    <h4 className="card-header bg-dark text-light">Not Started</h4>
                                    <ul id="list-toDo" className="list-group list-group-flush">
                                        <SingleTask />
                                    </ul>
                                </div>
                            </div>

                            <div className="col-12 col-md-6 col-xl-3 mb-3">
                                <div className="card">
                                    <h4 className="card-header bg-dark text-light">Started</h4>
                                    <ul id="list-inProgress" className="list-group list-group-flush">
                                        <SingleTask />
                                        <SingleTask />
                                    </ul>
                                </div>
                            </div>
                            
                            <div className="col-12 col-md-6 col-xl-3 mb-3">
                                <div className="card">
                                    <h4 className="card-header bg-dark text-light">Complete</h4>
                                    <ul id="list-done" className="list-group list-group-flush">
                                        <SingleTask />
                                    </ul>
                                </div>
                            </div>
                           
                        </div>
                    </main>
                </div>
            </section >
        );
    }
}