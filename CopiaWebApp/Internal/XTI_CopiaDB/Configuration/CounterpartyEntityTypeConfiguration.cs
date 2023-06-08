namespace XTI_CopiaDB.Configuration;

internal sealed class CounterpartyEntityTypeConfiguration : IEntityTypeConfiguration<CounterpartyEntity>
{
    public void Configure(EntityTypeBuilder<CounterpartyEntity> builder)
    {
        builder.HasKey(c => c.ID);
        builder.Property(c => c.DisplayText).HasMaxLength(500);
        builder.Property(c => c.Url).HasMaxLength(500);
        builder.Property(c => c.TimeDeleted).HasDefaultValue(DateTimeOffset.MaxValue);
        builder.HasOne<PortfolioEntity>()
            .WithMany()
            .HasForeignKey(c => c.PortfolioID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.ToTable("Couterparties");
    }
}
