import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Taskboard } from './components/TaskBoard';
import './custom.css'
import { AddTask } from './components/AddTask';
import { UpdateTask } from './components/UpdateTask';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Taskboard} />
        <Route path='/addtask' component={AddTask}  />
        <Route path='/updatetask/:id' component={UpdateTask}  />
      </Layout>
    );
  }
}
