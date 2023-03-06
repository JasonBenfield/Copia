namespace XTI_CopiaWebAppApi;

public sealed class CopiaRoles
{
    public static readonly CopiaRoles Instance = new();
    public AppRoleName Admin { get; } = AppRoleName.Admin;
    public AppRoleName PortfolioOwner { get; } = new(nameof(PortfolioOwner));
}
