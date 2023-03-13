namespace XTI_Copia.Abstractions;

public sealed class EditTemplateStringRequest
{
    public int ID { get; set; }
    public bool CanEdit { get; set; }
    public AddTemplateStringPartRequest[] Parts { get; set; } = new AddTemplateStringPartRequest[0];
}