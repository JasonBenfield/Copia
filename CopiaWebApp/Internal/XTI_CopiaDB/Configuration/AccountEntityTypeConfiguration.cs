namespace XTI_CopiaDB.Configuration;

internal sealed class AccountEntityTypeConfiguration : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.Property(a => a.AccountName).HasMaxLength(500).HasDefaultValue("");
        builder.Property(a => a.AccountType).HasDefaultValue(0);
        builder.HasOne<PortfolioEntity>()
            .WithMany()
            .HasForeignKey(a => a.PortfolioID);
        builder.ToTable("Accounts");
    }
}
