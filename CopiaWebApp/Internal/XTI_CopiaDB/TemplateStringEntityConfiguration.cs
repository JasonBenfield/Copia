namespace XTI_CopiaDB;

internal sealed class TemplateStringEntityConfiguration : IEntityTypeConfiguration<TemplateStringEntity>
{
    public void Configure(EntityTypeBuilder<TemplateStringEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.HasOne<PortfolioEntity>()
            .WithMany()
            .HasForeignKey(a => a.PortfolioID);
        builder.ToTable("TemplateStrings");
    }
}
