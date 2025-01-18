using XTI_Core.EF;

namespace XTI_CopiaDB.EF;

public sealed class EfCopiaDB
{
    public EfCopiaDB(CopiaDbContext context)
    {
        Context = context;
    }

    internal CopiaDbContext Context { get; }

    private EfPortfolios? portfolios;

    public EfPortfolios Portfolios { get => portfolios ??= new(this); }

    private EfActivities? activities;

    public EfActivities Activities { get => activities ??= new(this); }

    private EfCounterparties? counterparties;

    public EfCounterparties Counterparties { get => counterparties ??= new(this); }

    public Task<T> Transaction<T>(Func<Task<T>> action) => Context.Transaction(action);
}
