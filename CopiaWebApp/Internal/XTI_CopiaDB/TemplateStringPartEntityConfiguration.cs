namespace XTI_CopiaDB;

internal sealed class TemplateStringPartEntityConfiguration : IEntityTypeConfiguration<TemplateStringPartEntity>
{
    public void Configure(EntityTypeBuilder<TemplateStringPartEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.HasIndex(a => new { a.TemplateStringID, a.Sequence }).IsUnique();
        builder.Property(a => a.FixedText).HasMaxLength(500);
        builder.HasOne<TemplateStringEntity>()
            .WithMany()
            .HasForeignKey(a => a.TemplateStringID);
        builder.ToTable("TemplateStringParts");
    }
}
