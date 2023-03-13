namespace XTI_Copia.Abstractions;

public sealed record TemplateStringModel
(
    int ID, 
    bool CanEdit, 
    TemplateStringDataType DataType, 
    TemplateStringPartModel[] Parts
)
{
    public TemplateStringModel()
        : this(0, true, TemplateStringDataType.Values.GetDefault(), new TemplateStringPartModel[0])
    {
    }
}
