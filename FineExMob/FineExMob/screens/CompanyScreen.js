import * as React from 'react';
import { StyleSheet, ImageBackground } from 'react-native';

import bgImage from '../assets/images/bgImage.jpg'

export default function CompanyScreen () {
    return (
        <ImageBackground source={bgImage} style={styles.backgroundContainer}>

        </ImageBackground>
    );
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