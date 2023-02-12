using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolios;

internal sealed class PortfolioPermissions
{
    private readonly IUserContext userContext;

    public PortfolioPermissions(IUserContext userContext)
    {
        this.userContext = userContext;
    }

    public async Task<PortfolioPermissionModel[]> GetPermissions(PortfolioModel[] portfolios)
    {
        var userContextModel = await userContext.User();
        var modifierIDs = userContextModel.ModifiedRoles
            .Where(mr => mr.ModifierCategory.Name.Equals(CopiaInfo.ModCategories.Portfolio))
            .Select(mr => int.Parse(mr.Modifier.ModKey.Value))
            .ToArray();
        return portfolios
            .Select(p =>
            {
                var roles = GetRoles(userContextModel, p);
                return new PortfolioPermissionModel
                (
                    p,
                    CanView: roles.Any(r => r.EqualsAny(CopiaInfo.Roles.PortfolioOwner)),
                    CanEdit: roles.Any(r => r.EqualsAny(CopiaInfo.Roles.PortfolioOwner))
                );
            })
            .ToArray();
    }

    private AppRoleName[] GetRoles(UserContextModel userContextModel, PortfolioModel p) =>
        userContextModel.ModifiedRoles
            .Where
            (
                mr =>
                    mr.ModifierCategory.Name.Equals(CopiaInfo.ModCategories.Portfolio) &&
                mr.Modifier.ModKey.Equals(p.PublicKey)
            )
            .FirstOrDefault()?.Roles
            .Select(r => r.Name).ToArray()
        ?? new AppRoleName[0];
}
