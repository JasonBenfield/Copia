namespace XTI_CopiaDB.Configuration;

internal sealed class ActivityTemplateEntityConfiguration : IEntityTypeConfiguration<ActivityTemplateEntity>
{
    public void Configure(EntityTypeBuilder<ActivityTemplateEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.Property(a => a.TemplateName).HasMaxLength(100).HasDefaultValue("");
        builder.Property(a => a.ActivityName).HasMaxLength(1000).HasDefaultValue("");
        builder.HasOne<PortfolioEntity>()
            .WithMany()
            .HasForeignKey(a => a.PortfolioID)
            .OnDelete(DeleteBehavior.Restrict);
        builder.ToTable("ActivityTemplates");
    }
}
