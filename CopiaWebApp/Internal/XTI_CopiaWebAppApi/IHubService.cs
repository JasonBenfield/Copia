namespace XTI_CopiaWebAppApi;

public interface IHubService
{
    public Task AddModifier(ModifierCategoryName categoryName, ModifierKey modKey, string targetKey, string displayText, CancellationToken ct);

    public Task AssignRoleToUser(AppUserName userName, ModifierCategoryName categoryName, ModifierKey modKey, AppRoleName roleName, CancellationToken ct);
}
