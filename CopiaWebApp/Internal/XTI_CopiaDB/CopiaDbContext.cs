using XTI_Core;
using XTI_Core.EF;

namespace XTI_CopiaDB;

public sealed class CopiaDbContext : DbContext
{
    private readonly UnitOfWork unitOfWork;

    public CopiaDbContext(DbContextOptions<CopiaDbContext> options) : base(options)
    {
        unitOfWork = new UnitOfWork(this);
        Portfolios = new EfDataRepository<PortfolioEntity>(this);
        Accounts = new EfDataRepository<AccountEntity>(this);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PortfolioEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
    }

    public DataRepository<PortfolioEntity> Portfolios { get; }

    public DataRepository<AccountEntity> Accounts { get; }

    public Task Transaction(Func<Task> action) => unitOfWork.Execute(action);

    public Task<T> Transaction<T>(Func<Task<T>> action) => unitOfWork.Execute(action);
}
