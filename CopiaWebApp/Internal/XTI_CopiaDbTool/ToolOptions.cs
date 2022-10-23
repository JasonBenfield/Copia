namespace XTI_CopiaDbTool;

internal sealed class ToolOptions
{
    public string Command { get; set; } = "";
    public string BackupFilePath { get; set; } = "";
    public bool Force { get; set; }
}