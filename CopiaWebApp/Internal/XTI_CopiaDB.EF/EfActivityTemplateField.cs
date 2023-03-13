using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivityTemplateField
{
    private readonly ActivityTemplateFieldEntity entity;

    internal EfActivityTemplateField(ActivityTemplateFieldEntity entity)
    {
        this.entity = entity;
    }

    public ActivityTemplateFieldModel ToModel() =>
        new ActivityTemplateFieldModel
        (
            ID: entity.ID,
            FieldType: ActivityFieldType.Values.Value(entity.FieldType),
            FieldCaption: entity.FieldCaption,
            Accessibility: ActivityFieldAccessibility.Values.Value(entity.Accessibility)
        );
}
