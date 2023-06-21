using XTI_CopiaDB.Configuration;
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
        ActivityTemplates = new EfDataRepository<ActivityTemplateEntity>(this);
        ActivityTemplateFields = new EfDataRepository<ActivityTemplateFieldEntity>(this);
        TemplateStrings = new EfDataRepository<TemplateStringEntity>(this);
        TemplateStringParts = new EfDataRepository<TemplateStringPartEntity>(this);
        Counterparties = new EfDataRepository<CounterpartyEntity>(this);
        Activities = new EfDataRepository<ActivityEntity>(this);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PortfolioEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityTemplateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityTemplateFieldEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateStringEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateStringPartEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CounterpartyEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ActivityEntityConfiguration());
    }

    public DataRepository<PortfolioEntity> Portfolios { get; }

    public DataRepository<AccountEntity> Accounts { get; }

    public DataRepository<ActivityTemplateEntity> ActivityTemplates { get; }

    public DataRepository<ActivityTemplateFieldEntity> ActivityTemplateFields { get; }

    public DataRepository<TemplateStringEntity> TemplateStrings { get; }

    public DataRepository<TemplateStringPartEntity> TemplateStringParts { get; }

    public DataRepository<CounterpartyEntity> Counterparties { get; }

    public DataRepository<ActivityEntity> Activities { get; }

    public Task Transaction(Func<Task> action) => unitOfWork.Execute(action);

    public Task<T> Transaction<T>(Func<Task<T>> action) => unitOfWork.Execute(action);
}
