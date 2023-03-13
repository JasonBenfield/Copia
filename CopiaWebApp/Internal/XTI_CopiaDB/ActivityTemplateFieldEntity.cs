namespace XTI_CopiaDB;

public sealed class ActivityTemplateFieldEntity
{
    public int ID { get; set; }
    public int TemplateID { get; set; }
    public int FieldType { get; set; }
    public string FieldCaption { get; set; } = "";
    public int Accessibility { get; set; }
}
