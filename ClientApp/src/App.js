import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { FetchData } from './components/FetchData';
import { Taskboard } from './components/TaskBoard';

import './custom.css'
import { AddTask } from './components/AddTask';
import { UpdateTask } from './components/UpdateTask';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route path='/fetch-data' component={FetchData} />
        <Route exact path='/' component={Taskboard} />
        <Route path='/addtask' component={AddTask}  />
        <Route path='/updatetask/:id' component={UpdateTask}  />
      </Layout>
    );
  }
}
