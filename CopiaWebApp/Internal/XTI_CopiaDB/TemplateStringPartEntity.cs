namespace XTI_CopiaDB;

public sealed class TemplateStringPartEntity
{
    public int ID { get; set; }
    public int TemplateStringID { get; set; }
    public int Sequence { get; set; }
    public int PartType { get; set; }
    public int ArrayType { get; set; }
    public int ArrayIndex { get; set; }
    public int FieldType { get; set; }
    public string FixedText { get; set; } = "";
}
