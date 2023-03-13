namespace XTI_Copia.Abstractions;

public sealed class AddTemplateStringPartRequest
{
    public int PartType { get; set; }
    public int ArrayType { get; set; }
    public int ArrayIndex { get; set; }
    public int FieldType { get; set; }
    public string FixedText { get; set; } = "";
}