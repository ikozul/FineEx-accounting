import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import * as React from 'react';
import { Component } from 'react';
import { Platform, StatusBar, StyleSheet, View, ImageBackground } from 'react-native';

import useCachedResources from './hooks/useCachedResources';
import BottomTabNavigator from './navigation/BottomTabNavigator';
import LinkingConfiguration from './navigation/LinkingConfiguration';

import bgImage from './assets/images/bgImage.jpg'

import Login from './screens/LoginScreen';
import Secured from './screens/Secured';
import { post } from './Services/ApiService';
import { get } from './Services/ApiService';
import { loginResponseSetter } from './Services/LoginResponseSetter';


const Stack = createStackNavigator();

export default class App extends Component {

  state = {
    hasLoginError: false,
    isLoggedIn: false,
    email: '',
    password: '',
    companies: [],
    firstName: '',
    lastName: '',
    id: undefined,
    isActive: false,
    roleId: undefined
  }

  render() {
    const{email, password}=this.state;

    console.log('state', this.state)

    if (this.state.isLoggedIn)
      return <Secured
        onNameChange={(firstName, lastName) => this.setState({firstName, lastName})}
        onLogoutPress={() => this.setState({ isLoggedIn: false })}
        {...this.state}
      />;
    else
      return <Login
        email={this.state.email}
        password={this.state.password}
        hasLoginError={this.state.hasLoginError}
        onEmailChange={Text => this.setState({ email: Text })}
        onPasswordChange={Text => this.setState({ password: Text })}
        onLoginPress={async () => {
          const result = await post({email, password}, 'account/Login')
          if(!result) {
            this.setState({hasLoginError: true});
            return;
          }
          this.setState({hasLoginError: false});
          const loginResponse = loginResponseSetter(result);
          this.setState({ isLoggedIn: true, ...loginResponse })          
        }}
      />;

    
  }

}
