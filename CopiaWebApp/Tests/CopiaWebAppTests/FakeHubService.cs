using XTI_App.Abstractions;
using XTI_App.Fakes;
using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class FakeHubService : IHubService
{
    private readonly FakeAppContext appContext;
    private readonly FakeUserContext userContext;

    public FakeHubService(FakeAppContext appContext, FakeUserContext userContext)
    {
        this.appContext = appContext;
        this.userContext = userContext;
    }

    public Task AddPortfolioModifier(PortfolioModel portfolio)
    {
        var app = appContext.GetCurrentApp();
        appContext.AddModifier
        (
            app, 
            CopiaInfo.ModCategories.Portfolio, 
            portfolio.PublicKey,
            portfolio.ID.ToString()
        );
        return Task.CompletedTask;
    }

    public Task AssignPortfolioRoleToUser(AppUserName userName, PortfolioModel portfolio, AppRoleName roleName)
    {
        var user = userContext.GetUser(userName);
        var modCategory = appContext.GetCurrentApp().ModifierCategory(CopiaInfo.ModCategories.Portfolio);
        var modifier = modCategory.Modifier(portfolio.PublicKey);
        var modifiedRole = user.ModifiedRoles
            .Where(mr => mr.Modifier.ModKey.Equals(portfolio.PublicKey))
            .FirstOrDefault()
            ?? new UserContextRoleModel(modCategory.ModifierCategory, modifier, new AppRoleModel[0]);
        modifiedRole = modifiedRole with
        {
            Roles = modifiedRole.Roles
                .Union
                (
                    new[] { appContext.GetCurrentApp().Role(roleName) }
                )
                .Distinct()
                .ToArray()
        };
        userContext.Update
        (
            user,
            u => u with
            {
                ModifiedRoles = u.ModifiedRoles
                    .Where(mr => !mr.Modifier.ModKey.Equals(portfolio.PublicKey))
                    .Union(new[] { modifiedRole })
                    .ToArray()
            }
        );
        return Task.CompletedTask;
    }
}
