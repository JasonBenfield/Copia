namespace XTI_Copia.Abstractions;

public sealed record CounterpartySearchResult(CounterpartyModel[] Counterparties, int Total)
{
    public CounterpartySearchResult()
        : this(new CounterpartyModel[0], 0)
    {
    }
}
