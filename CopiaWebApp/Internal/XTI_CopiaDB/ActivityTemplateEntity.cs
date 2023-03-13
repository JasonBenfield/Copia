namespace XTI_CopiaDB;

public sealed class ActivityTemplateEntity
{
    public int ID { get; set; }
    public int PortfolioID { get; set; }
    public string TemplateName { get; set; } = "";
    public int ActivityNameTemplateStringID { get; set; }
}
