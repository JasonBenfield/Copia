namespace XTI_Copia.Abstractions;

public sealed record TemplateStringPartModel
(
    int ID, 
    TemplateStringPartType PartType, 
    TemplateStringArrayType ArrayType, 
    int ArrayIndex, 
    TemplateStringFieldType FieldType, 
    string FixedText
)
{
}
