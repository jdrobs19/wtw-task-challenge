import React, { Component } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { SingleTask } from './SingleTask';
import './TaskBoard.css';

export class Taskboard extends Component {
    static displayName = Taskboard.name;

    render() {
        return (
            <section>
                <div>
                    <header className="col-12 col-lg-3 bg-dark text-light sticky-top d-flex flex-column p-4 p-lg-3">
                        <NavLink id="create-task" className="btn btn-block btn-add" data-toggle="modal" data-target="#task-form-modal" tag={Link} to="/addtask"><span className="oi oi-plus mr-2"></span>Add
                            Task</NavLink>
                        <span className="oi oi-task display-1 text-center mb-2 d-none d-lg-block mt-auto"></span>
                    </header>
                    <main className="col-12 col-lg-9 d-flex flex-column">
                        <div className="m-5 row justify-content-around">
                            {/* <!--todo start--> */}
                            <div className="col-12 col-md-6 col-xl-3 mb-3">
                                <div className="card">
                                    <h4 className="card-header bg-dark text-light">To Do</h4>
                                    <ul id="list-toDo" className="list-group list-group-flush">
                                    </ul>
                                </div>
                            </div>
                            {/*  <!--todo end-->

                                <!--in progress start-->  */}
                            <div className="col-12 col-md-6 col-xl-3 mb-3">
                                <div className="card">
                                    <h4 className="card-header bg-dark text-light">In Progess</h4>
                                    <ul id="list-inProgress" className="list-group list-group-flush">
                                        
                                    </ul>
                                </div>
                            </div>
                            {/* <!--in progress end-->
                            
                                <!--done start--> */}
                            <div className="col-12 col-md-6 col-xl-3 mb-3">
                                <div className="card">
                                    <h4 className="card-header bg-dark text-light">Done</h4>
                                    <ul id="list-done" className="list-group list-group-flush">

                                    </ul>
                                </div>
                            </div>
                            {/* <!--done end--> */}
                        </div>
                    </main>
                </div>
            </section >
        );
    }
}