import React, { Component } from 'react';
import {
    ScrollView,
    Text,
    TextInput,
    View,
    Button,
    StyleSheet,
    ImageBackground,
    TouchableOpacity
} from 'react-native';

import bgImage from '../assets/images/bgImage.jpg'

export default class Login extends Component {

    render() {
        const { email, password, hasLoginError } = this.props;
        return (
            <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                <ScrollView style={styles.container}>
                    
                    <View style={styles.inputContainer}>
                        <TextInput
                            value={email}
                            onChange={event => {this.props.onEmailChange(event.nativeEvent.text)}}
                            style={styles.input}
                            placeholder={'Email'}
                            placeholderTextColor={'rgba(255,255,255,0.3)'}
                            underlineColorAndroid='transparent'
                        />
                    </View>
                    <View style={styles.inputContainer}>
                        <TextInput
                            value={password}
                            onChange={event => {this.props.onPasswordChange(event.nativeEvent.text)}}
                            style={styles.input}
                            placeholder={'Password'}
                            secureTextEntry={true}
                            placeholderTextColor={'rgba(255,255,255,0.3)'}
                            underlineColorAndroid='transparent'
                        />
                    </View>
                    {hasLoginError && <Text style={styles.loginError}>Incorrect credentials!</Text>}
                    <View style={styles.buttonContainer} >
                        <TouchableOpacity style={styles.buttonStyle} onPress={this.props.onLoginPress}>
                            <Text style={styles.buttonText}>Login</Text>
                        </TouchableOpacity>
                        <TouchableOpacity style={styles.buttonStyle}>
                            <Text style={styles.buttonText}>Register</Text>
                        </TouchableOpacity>
                    </View>
                </ScrollView>
            </ImageBackground>
        )
    }
}

const styles = StyleSheet.create({
    backgroundContainer: {
        flex: 1,
        width: null,
        height: null,
        justifyContent: "center",
        alignItems: "center",
    },
    inputContainer: {
        marginTop: 20,
    },
    buttonContainer: {
        marginTop: 60,
        alignItems: "center"
    },
    container: {
        padding: 20,
        marginTop: 100,
    },
    text: {
        fontSize: 16,
        color: 'rgba(96,100,109, 0.3)',
        lineHeight: 24,
        textAlign: 'center',
    },
    input: {
        width: 200,
        height: 45,
        borderRadius: 45,
        fontSize: 16,
        paddingLeft: 45,
        backgroundColor: 'rgba(0,0,0,0.3)',
        color: 'rgba(255,255,255,1)',
        marginTop: 40,
        justifyContent: 'center'
    },
    buttonStyle: {
        width: 200,
        height: 45,
        borderRadius: 45,
        fontSize: 16,
        marginBottom: 20,
        justifyContent: 'center',
        alignItems: 'center',
        color: 'rgba(255,255,255,1)',
        backgroundColor: 'rgba(120,120,120,0.5)',
    },
    buttonText: {
        color: "white",
        fontSize: 18
    },
    loginError: {
        textAlign: "center",
        color: "#b71540",
        marginTop: 20,
        fontSize: 18
    }
});