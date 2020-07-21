import * as React from 'react';
import { View, Text, StyleSheet } from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';

export class Receipt extends React.Component {

    state = {
        showDetails: false
    }

    render() {
        const { item } = this.props;

        return (
            <View>
                <TouchableOpacity style={styles.receiptContainer} onPress={() => this.setState({ showDetails: !this.state.showDetails })}>
                    <Text style={styles.text}>{item.invoiceDate}</Text>
                    <Text style={styles.text}>{item.totalPrice} $</Text>
                    {this.state.showDetails && (
                    <View>
                        <Text style={styles.text}>{item.invoiceNumber}</Text>
                        <Text style={styles.text}>Receiver: {item.receiver.Name}</Text>
                        <Text style={styles.text}>Sender: {item.sender.Name}</Text>
                        <Text style={styles.text}>{item.vatSwiftBankClient}</Text>
                    </View>

                )}
                </TouchableOpacity>
                

            </View>
        )
    }
}

const styles = StyleSheet.create({
    receiptContainer: {
        width: 360,
        borderRadius: 10,
        backgroundColor: "white",
        flexDirection: "row",
        alignItems: "stretch",
        justifyContent: "space-between",
        paddingVertical: 10,
        paddingHorizontal: 10,
        marginVertical: 5
    },
    text: {
        color: "black",
        fontSize: 12
    }
});