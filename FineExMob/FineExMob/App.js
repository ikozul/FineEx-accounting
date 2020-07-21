import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import * as React from 'react';
import {Component} from 'react';
import { Platform, StatusBar, StyleSheet, View, ImageBackground } from 'react-native';

import useCachedResources from './hooks/useCachedResources';
import BottomTabNavigator from './navigation/BottomTabNavigator';
import LinkingConfiguration from './navigation/LinkingConfiguration';

import bgImage from './assets/images/bgImage.jpg'

import Login from './screens/LoginScreen';
import Secured from './screens/Secured';


const Stack = createStackNavigator();

export default class App extends Component {

  state = {
    isLoggedIn: false
  }

  render() {

    if (this.state.isLoggedIn) 
      return <Secured 
          onLogoutPress={() => this.setState({isLoggedIn: false})}
        />;
    else 
      return <Login 
          onLoginPress={() => this.setState({isLoggedIn: true})}
        />;
  }

}
