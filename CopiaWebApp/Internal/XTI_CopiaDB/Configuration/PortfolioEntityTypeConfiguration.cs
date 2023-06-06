namespace XTI_CopiaDB.Configuration;

internal sealed class PortfolioEntityTypeConfiguration : IEntityTypeConfiguration<PortfolioEntity>
{
    public void Configure(EntityTypeBuilder<PortfolioEntity> builder)
    {
        builder.HasKey(p => p.ID);
        builder.Property(p => p.PortfolioName).HasMaxLength(500);
        builder.ToTable("Portfolios");
    }
}
