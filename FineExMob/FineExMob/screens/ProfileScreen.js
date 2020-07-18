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
import { Ionicons } from '@expo/vector-icons';
import { TouchableOpacity } from 'react-native-gesture-handler';

export default class ProfileScreen extends Component {
    render() {
        const { firstName, lastName, email, companies } = this.props;
        return (
            <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                <Ionicons name="ios-person" size={100} color="white" />
                <Text>{`${firstName} ${lastName}`}</Text>
                <Text>{email}</Text>
                {//<Text>{companies.map(company => company.Name).join(', ')}</Text>
                }
                <TouchableOpacity>
                    <Text>Logout</Text>
                </TouchableOpacity>
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