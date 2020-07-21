import * as React from 'react';
import { StyleSheet, ImageBackground, View, Text } from 'react-native';

import { Ionicons } from '@expo/vector-icons';

import bgImage from '../assets/images/bgImage.jpg'
import { ScrollView, TouchableOpacity } from 'react-native-gesture-handler';
import { get } from '../Services/ApiService';
import { ReceiptResponseSetter } from '../Services/ReceiptResponseSetter';
import { Receipt } from '../components/Receipt';

export default class CompanyScreen extends React.Component {

    state = {
        selectedCompanyId: undefined,
        receipts: []
    }

    render() {
        const { companies, id: userId } = this.props;
        const { selectedCompanyId, receipts } = this.state;
        console.log("render", this.state.receipts)

        const senderReceipts = receipts.filter(item => item.sender.Id === selectedCompanyId);
        const receiverReceipts = receipts.filter(item => item.receiver.Id === selectedCompanyId);
        return (
            !selectedCompanyId ? (
                <ImageBackground source={bgImage} style={styles.backgroundContainer}>
                    <ScrollView>
                        {
                            companies.map((company) => (
                                <TouchableOpacity key={company.Id} style={styles.companyContainer} onPress={async () => {
                                    this.setState({ selectedCompanyId: company.Id })
                                    const result = await get(`Invoices/${company.Id}`)
                                    const receipts = result.map(item => ReceiptResponseSetter(item))
                                    this.setState({receipts})
                                }}>
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
                            <Text style={styles.receiptHeader}>As a Sender:</Text>
                            {senderReceipts.length > 0 ? senderReceipts.map(item => (
                                <Receipt item={item} key={item.id} />
                            )) : <Text style={styles.placeholderText}>No receipts</Text>}
                            <Text style={styles.receiptHeader}>As a Receiver:</Text>
                            {receiverReceipts.length > 0 ? receiverReceipts.map(item => (
                                <Receipt item={item} key={item.id} />
                            )): <Text style={styles.placeholderText}>No receipts</Text>}
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
    receiptHeader: {
        color: "white",
        fontSize: 14,
        marginVertical: 5
    },
    placeholderText: {
        color: "white",
        fontSize: 14,
        marginVertical: 5,
        opacity: 0.6,
    },
    backButton: {
        width: "100%",
        justifyContent: "flex-start",
        flexDirection: "row"
    }
});