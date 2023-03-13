namespace XTI_Copia.Abstractions;

public sealed record ActivityTemplateFieldModel
(
    int ID, 
    ActivityFieldType FieldType, 
    string FieldCaption, 
    ActivityFieldAccessibility Accessibility
)
{
    public ActivityTemplateFieldModel()
        :this(0, ActivityFieldType.Values.GetDefault(), "", ActivityFieldAccessibility.Values.GetDefault())
    {
    }
}
