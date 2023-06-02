namespace XTI_CopiaDB.Configuration;

internal sealed class ActivityTemplateFieldEntityConfiguration : IEntityTypeConfiguration<ActivityTemplateFieldEntity>
{
    public void Configure(EntityTypeBuilder<ActivityTemplateFieldEntity> builder)
    {
        builder.HasKey(a => a.ID);
        builder.Property(a => a.FieldCaption).HasMaxLength(100);
        builder.HasOne<ActivityTemplateEntity>()
            .WithMany()
            .HasForeignKey(a => a.TemplateID);
        builder.ToTable("ActivityTemplateFields");
    }
}
