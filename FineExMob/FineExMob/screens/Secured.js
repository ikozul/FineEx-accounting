import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import React, { Component } from 'react';
import {
    ScrollView,
    Text,
    View,
    Button,
    StyleSheet
} from 'react-native';

import BottomTabNavigator from '../navigation/BottomTabNavigator';
import LinkingConfiguration from '../navigation/LinkingConfiguration';

const Stack = createStackNavigator();

export default class Secured extends Component {
    render() {
        return (
            <View style={styles.container}>
                {Platform.OS === 'ios' && <StatusBar barStyle="dark-content" />}
                <NavigationContainer linking={LinkingConfiguration}>
                    <Stack.Navigator>
                        <Stack.Screen name="Root" component={BottomTabNavigator}/>
                    </Stack.Navigator>
                </NavigationContainer>
            </View>
        )

        // return (
        //     <ScrollView style={{ padding: 20 }}>
        //         <Text
        //             style={{ fontSize: 27 }}>
        //             Welcome
        //         </Text>
        //         <View style={{ margin: 20 }} />
        //         <Button
        //             onPress={this.props.onLogoutPress}
        //             title="Logout"
        //         />
        //     </ScrollView>
        // )
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
    container: {
        position: "absolute",
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
        flex: 1,
    },
});