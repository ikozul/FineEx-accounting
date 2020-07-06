import React, { Component } from 'react';
import { registerRootComponent } from 'expo';

import LoginScreen from './Screens/LoginScreen'
import CompanyScreen from './Screens/CompanyScreen'

class LoginService extends Component {

    state = {
        isLoggedIn: false
    }

    render() {

        if (this.state.isLoggedIn)
            return <CompanyScreen
                onLogoutPress={() => this.setState({ isLoggedIn: false })}
            />;
        else
            return <LoginScreen
                onLoginPress={() => this.setState({ isLoggedIn: true })}
            />;
    }

}

registerRootComponent(LoginService)