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
        return (
            <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                <ScrollView style={styles.container}>
                    <View style={styles.inputContainer}>
                        <TextInput
                            style={styles.input}
                            placeholder={'Email'}
                            placeholderTextColor={'rgba(255,255,255,0.3)'}
                            underlineColorAndroid='transparent'
                        />
                    </View>
                    <View style={styles.inputContainer}>
                        <TextInput
                            style={styles.input}
                            placeholder={'Password'}
                            secureTextEntry={true}
                            placeholderTextColor={'rgba(255,255,255,0.3)'}
                            underlineColorAndroid='transparent'
                        />
                    </View>
                    <View style={styles.buttonContainer} >
                        <Button title='Login' style={styles.loginButton} onPress={this.props.onLoginPress}>
                        </Button>
                        <Button title='Register' style={styles.registerButton}>
                        </Button>
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
        marginTop: 100,
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
        marginHorizontal: 25,
        marginTop: 40,
        justifyContent: 'center'
    },
    loginButton: {
        width: 100,
        height: 45,
        borderRadius: 45,
        fontSize: 16,
        marginHorizontal: 50,
        marginBottom: 50,
        justifyContent: 'center',
        color: 'rgba(255,255,255,1)',
        backgroundColor: 'rgba(120,120,120,0.5)',
    },
    registerButton: {
        width: 100,
        height: 45,
        borderRadius: 45,
        fontSize: 16,
        marginHorizontal: 50,
        justifyContent: 'center',
        color: 'rgba(255,255,255,1)',
        backgroundColor: 'rgba(150,150,150,0.5)',
    }
});