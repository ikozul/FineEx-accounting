export function ReceiptResponseSetter(response) {
    const {
        Id:id,
        Approved:approved,
        DueDate:duedate,
        InvoiceDate:invoiceDate,
        InvoiceNumber:invoiceNumber,
        PaymentMethod:paymentMethod,
        Items:items,
        PriceWithoutVat:priceWithoutVat,
        Receiver:receiver,
        Sender:sender,
        TotalPrice:totalPrice,
        UniqueIdentifierOfInvoice:uniqueIdentifierOfInvoice,
        VatPercentage:vatPercentage,
        VatSwiftBankClient:vatSwiftBankClient
    } = response;
    return {
        id,
        approved,
        duedate,
        invoiceDate,
        invoiceNumber,
        paymentMethod,
        items,
        priceWithoutVat,
        receiver,
        sender,
        totalPrice,
        uniqueIdentifierOfInvoice,
        vatPercentage,
        vatSwiftBankClient
    }
}