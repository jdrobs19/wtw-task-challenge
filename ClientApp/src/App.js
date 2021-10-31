import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Taskboard } from './components/TaskBoard';

import './custom.css'
import { AddTask } from './components/AddTask';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/taskboard' component={Taskboard} />
        <Route path='/addtask' component={AddTask}  />
      </Layout>
    );
  }
}
