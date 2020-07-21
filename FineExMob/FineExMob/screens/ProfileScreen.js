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
import { TouchableOpacity, TextInput } from 'react-native-gesture-handler';

import { put } from '../Services/ApiService';

export default class ProfileScreen extends Component {

    state = {
        isInEditMode: false,
        tempFirstName: this.props.firstName,
        tempLastName: this.props.lastName
    }

    render() {
        const { firstName, lastName, email, id, companies, onLogoutPress, onNameChange } = this.props;
        const { isInEditMode } = this.state;

        return (
            !isInEditMode ? (
                <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                    <Ionicons name="ios-person" size={100} color="white" style={{ marginBottom: 20 }} />
                    <Text style={styles.text}>{`${firstName} ${lastName}`}</Text>
                    <Text style={styles.text}>{email}</Text>
                    <Text style={styles.text}>{companies.map(company => company.Name).join(', ')}</Text>
                    <TouchableOpacity style={styles.editButton} onPress={() => this.setState({ isInEditMode: true })}>
                        <Text style={styles.buttonText}>Edit</Text>
                    </TouchableOpacity>
                    <TouchableOpacity style={styles.logoutButton} onPress={onLogoutPress}>
                        <Text style={styles.buttonText}>Logout</Text>
                    </TouchableOpacity>
                </ImageBackground>
            ) : (
                    <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                        <Text>Edit mode</Text>
                        <TouchableOpacity style={styles.backButton} onPress={() => this.setState({ isInEditMode: false })}>
                            <Ionicons name="ios-arrow-round-back" size={50} />
                        </TouchableOpacity>
                        <TextInput style={styles.text} onChangeText={(text) => this.setState({tempFirstName:text})}>{firstName}</TextInput>
                        <TextInput style={styles.text} onChangeText={(text) => this.setState({tempLastName:text})}>{lastName}</TextInput>
                        <TouchableOpacity style={styles.editButton} onPress={async () => {
                            onNameChange(this.state.tempFirstName, this.state.tempLastName);
                            this.setState({ isInEditMode: false });
                            const result = await put({id, firstName, lastName}, `users/${id}?id=${id}&firstName=${this.state.tempFirstName}&lastName=${this.state.tempLastName}`)
                        }}>
                            <Text style={styles.buttonText}>Save</Text>
                        </TouchableOpacity>

                    </ImageBackground>

                )

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
    text: {
        fontSize: 18,
        color: "white",
    },
    logoutButton: {
        width: 200,
        height: 45,
        borderRadius: 45,
        fontSize: 16,
        marginBottom: 20,
        justifyContent: 'center',
        alignItems: 'center',
        color: 'rgba(255,255,255,1)',
        backgroundColor: 'rgba(120,120,120,0.5)',
        marginTop: 100
    },
    editButton: {
        width: 100,
        height: 30,
        borderRadius: 45,
        fontSize: 16,
        marginBottom: 20,
        justifyContent: 'center',
        alignItems: 'center',
        color: 'rgba(255,255,255,1)',
        backgroundColor: 'rgba(120,120,120,0.5)',
        marginTop: 20
    },
    backButton: {

    },
    buttonText: {
        color: "white",
        fontSize: 18
    }
});