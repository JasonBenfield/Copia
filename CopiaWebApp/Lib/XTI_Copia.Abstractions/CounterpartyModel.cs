namespace XTI_Copia.Abstractions;

public sealed record CounterpartyModel(int ID, string DisplayText, string Url)
{
    public CounterpartyModel()
        : this(0, "", "")
    {
    }
}
