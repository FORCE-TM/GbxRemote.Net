namespace GbxRemoteNet
{
    public enum BillState
    {
        CreatingTransaction = 1,
        Issued = 2,
        ValidatingPayment = 3,
        Paid = 4,
        Refused = 5,
        Error = 6
    }
}
