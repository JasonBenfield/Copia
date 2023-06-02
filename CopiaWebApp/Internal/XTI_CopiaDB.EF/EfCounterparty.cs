using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfCounterparty
{
    private readonly CounterpartyEntity counterparty;

    public EfCounterparty(CounterpartyEntity counterparty)
    {
        this.counterparty = counterparty;
    }

    public CounterpartyModel ToModel() =>
        new CounterpartyModel
        (
            ID: counterparty.ID,
            DisplayText: counterparty.DisplayText,
            Url: counterparty.Url
        );
}
