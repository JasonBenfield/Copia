using XTI_App.Abstractions;
using XTI_App.Api;
using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;
using XTI_Hub.Abstractions;
using XTI_HubAppClient;

namespace XTI_CopiaImplementations;

public sealed class HcHubService : IHubService
{
    private readonly InstallationIDAccessor installationIDAccessor;
    private readonly HubAppClient hubClient;

    public HcHubService(InstallationIDAccessor installationIDAccessor, HubAppClient hubClient)
    {
        this.installationIDAccessor = installationIDAccessor;
        this.hubClient = hubClient;
    }

    public async Task AddModifier(ModifierCategoryName categoryName, ModifierKey modKey, string targetKey, string displayText, CancellationToken ct)
    {
        var installationID = await installationIDAccessor.Value();
        await hubClient.System.AddOrUpdateModifierByModKey
        (
            new SystemAddOrUpdateModifierByModKeyRequest
            (
                installationID,
                categoryName,
                modKey,
                targetKey,
                displayText
            ),
            ct
        );
    }

    public async Task AssignRoleToUser(AppUserName userName, ModifierCategoryName categoryName, ModifierKey modKey, AppRoleName roleName, CancellationToken ct)
    {
        var installationID = await installationIDAccessor.Value();
        await hubClient.System.SetUserAccess
        (
            new SystemSetUserAccessRequest
            (
                installationID,
                userName,
                new SystemSetUserAccessRoleRequest
                (
                    categoryName,
                    modKey,
                    roleName
                )
            ),
            ct
        );
    }
}