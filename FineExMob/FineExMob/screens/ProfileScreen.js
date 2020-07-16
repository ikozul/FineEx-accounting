import React, { Component } from 'react';
import {
    ScrollView,
    Text,
    View,
    Button,
    StyleSheet,
    ImageBackground
} from 'react-native';

import bgImage from '../assets/images/bgImage.jpg'

export default class ProfileScreen extends Component {
    render() {
        return (
            <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                {/* <Button onPress={this.props.onLogoutPress}
                    title="Logout"
                /> */}
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
});