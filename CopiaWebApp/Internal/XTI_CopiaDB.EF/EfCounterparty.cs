using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfCounterparty
{
    private readonly EfCopiaDB db;
    private readonly CounterpartyEntity counterparty;

    internal EfCounterparty(EfCopiaDB db, CounterpartyEntity counterparty)
    {
        this.db = db;
        this.counterparty = counterparty;
    }

    internal int ID { get => counterparty.ID; }

    public bool IsFound() => counterparty.ID > 0;

    public bool HasSameID(EfCounterparty efCounterparty) => counterparty.ID == efCounterparty.counterparty.ID;

    public Task Edit(EditCounterpartyForm editForm)
    {
        var displayText = editForm.DisplayText.Value()?.Trim() ?? "";
        var url = editForm.Url.Value()?.Trim() ?? "";
        return db.Context.Counterparties.Update
        (
            counterparty,
            c =>
            {
                c.DisplayText = displayText;
                c.Url = url;
            }
        );
    }

    public Task Delete(DateTimeOffset timeDeleted) =>
        db.Context.Counterparties.Update
        (
            counterparty,
            c => c.TimeDeleted = timeDeleted
        );

    public CounterpartyModel ToModel() =>
        new CounterpartyModel
        (
            ID: counterparty.ID,
            DisplayText: counterparty.DisplayText,
            Url: counterparty.Url
        );

}
