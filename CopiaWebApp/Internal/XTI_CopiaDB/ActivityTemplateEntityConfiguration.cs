namespace XTI_CopiaDB;

internal sealed class ActivityTemplateEntityConfiguration : IEntityTypeConfiguration<ActivityTemplateEntity>
{
    public void Configure(EntityTypeBuilder<ActivityTemplateEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.Property(a => a.TemplateName).HasMaxLength(100);
        builder.HasOne<PortfolioEntity>()
            .WithMany()
            .HasForeignKey(a => a.PortfolioID);
        builder.ToTable("ActivityTemplates");
    }
}
