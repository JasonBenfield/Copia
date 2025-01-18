using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApiActions.Portfolios;

public sealed class PortfolioPermissions
{
    private readonly IUserContext userContext;
    private readonly IAppContext appContext;

    public PortfolioPermissions(IUserContext userContext, IAppContext appContext)
    {
        this.userContext = userContext;
        this.appContext = appContext;
    }

    public async Task<PortfolioPermissionModel[]> GetPermissions(PortfolioModel[] portfolios)
    {
        var user = await userContext.User();
        var app = await appContext.App();
        var portfolioModCategory = app.ModCategory(CopiaModCategories.Instance.Portfolio);
        var permissions = new List<PortfolioPermissionModel>();
        foreach (var portfolio in portfolios)
        {
            var modifier = await appContext.Modifier(portfolioModCategory, portfolio.PublicKey);
            var roles = await userContext.UserRoles(user, modifier);
            var permission = new PortfolioPermissionModel
            (
                Portfolio: portfolio,
                CanView: roles.Any(r => r.Name.EqualsAny(CopiaRoles.Instance.PortfolioOwner)),
                CanEdit: roles.Any(r => r.Name.EqualsAny(CopiaRoles.Instance.PortfolioOwner))
            );
            permissions.Add(permission);
        }
        return permissions.ToArray();
    }
}
