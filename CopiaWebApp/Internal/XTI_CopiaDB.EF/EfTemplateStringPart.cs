using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfTemplateStringPart
{
    private readonly TemplateStringPartEntity entity;

    internal EfTemplateStringPart(TemplateStringPartEntity entity)
    {
        this.entity = entity;
    }

    public TemplateStringPartModel ToModel() =>
        new TemplateStringPartModel
        (
            entity.ID,
            TemplateStringPartType.Values.Value(entity.PartType),
            TemplateStringArrayType.Values.Value(entity.ArrayType),
            entity.ArrayIndex,
            TemplateStringFieldType.Values.Value(entity.FieldType),
            entity.FixedText
        );
}
