namespace XTI_Copia.Abstractions;

public sealed class GetAccountRequest
{
    public GetAccountRequest()
        :this(0)
    {    
    }

    public GetAccountRequest(int accountID)
    {
        AccountID = accountID;
    }

    public int AccountID { get; set; }
}
