namespace XTI_CopiaDB.Configuration;

internal sealed class ActivityEntityConfiguration : IEntityTypeConfiguration<ActivityEntity>
{
    public void Configure(EntityTypeBuilder<ActivityEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.Property(a => a.ActivityName).HasMaxLength(1000);
        builder.Property(a => a.Amount).HasPrecision(20, 2);
        builder.HasOne<PortfolioEntity>()
            .WithMany()
            .HasForeignKey(a => a.PortfolioID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<ActivityTemplateEntity>()
            .WithMany()
            .HasForeignKey(a => a.ActivityTemplateID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<CounterpartyEntity>()
            .WithMany()
            .HasForeignKey(a => a.CounterpartyID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.ToTable("Activities");
    }
}
