import * as React from 'react';
import { StyleSheet, ImageBackground, View, Text } from 'react-native';

import { Ionicons } from '@expo/vector-icons';

import bgImage from '../assets/images/bgImage.jpg'
import { ScrollView, TouchableOpacity } from 'react-native-gesture-handler';

export default class CompanyScreen extends React.Component {

    state = {
        selectedCompanyId: undefined
    }

    render() {
        const { companies } = this.props;
        const { selectedCompanyId } = this.state;

        return (
            !selectedCompanyId ? (
                <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                    <ScrollView>
                        {
                            companies.map((company) => (
                                <TouchableOpacity key={company.Id} style={styles.companyContainer} onPress={() => this.setState({ selectedCompanyId: company.Id })}>
                                    <Text style={styles.text} >{company.County}</Text>
                                    <Text style={styles.text} >{company.Name}</Text>
                                    <Text style={styles.text} >{company.City}</Text>
                                    <Text style={styles.text} >{company.Address}</Text>
                                </TouchableOpacity>
                            ))
                        }
                    </ScrollView>
                </ImageBackground>
            ) : (
                    <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                        <View style={styles.backButton}>
                            <TouchableOpacity onPress={() => {
                                this.setState({ selectedCompanyId: undefined })

                            }}>
                                <Ionicons color="white" name="ios-arrow-round-back" size={50} />
                            </TouchableOpacity>
                        </View>

                        <ScrollView>

                        </ScrollView>
                    </ImageBackground>
                )

        );
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
    companyContainer: {
        margin: 10,
        width: 300,
        padding: 10,
        backgroundColor: "white",
        borderRadius: 10
    },
    text: {
        fontSize: 14
    },
    backButton: {
        width: "100%",
        justifyContent: "flex-start",
        flexDirection: "row"
    }
});