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
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PortfolioEntityTypeConfiguration());
    }

    public DataRepository<PortfolioEntity> Portfolios { get; }

    public Task Transaction(Func<Task> action) => unitOfWork.Execute(action);
}
