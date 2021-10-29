import React, { Component } from 'react';
import './Tasks.css';

export class Tasks extends Component {
    static displayName = Tasks.name;

    render() {
        return (
            <section>
                <div>
                    <header className="col-12 col-lg-3 bg-dark text-light sticky-top d-flex flex-column p-4 p-lg-3">
                        <button id="create-task" className="btn btn-block btn-add" data-toggle="modal" data-target="#task-form-modal"><span className="oi oi-plus mr-2"></span>Add
                            Task</button>
                        <button id="remove-tasks" className="btn btn-block btn-delete"><span className="oi oi-trash mr-2"></span>Delete All Tasks</button>
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

                        <div id="trash" className="mt-auto overflow-hidden">
                            <div className="w-100 p-3 text-center bottom-trash"><span className="oi oi-trash"></span>
                                Drop Here to Remove.
                            </div>
                        </div>

                    </main>
                </div>

                {/* //   <!-- Modal-- > */}
                <div className="modal fade" id="task-form-modal" tabindex="-1" role="dialog" aria-labelledby="task-form-modal"
                    aria-hidden="true">
                    <div className="modal-dialog modal-dialog-centered" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title" id="task-form-modal">Add New Task</h5>
                                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div className="modal-body">
                                <form>
                                    <div className="form-group">
                                        <label for="modalTaskDescription">Task description</label>
                                        <textarea id="modalTaskDescription" rows="3" className="form-control"></textarea>
                                    </div>
                                    <div className="form-group">
                                        <label for="modalDueDate">Due date</label>
                                        <input type="text" className="form-control" id="modalDueDate" placeholder="mm/dd/yyyy" autocomplete="off" />
                                    </div>
                                </form>
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-close" data-dismiss="modal">Close</button>
                                <button type="button" className="btn btn-save">Save Task</button>
                            </div>
                        </div>
                    </div>
                </div>
            </section >
        );
    }
}