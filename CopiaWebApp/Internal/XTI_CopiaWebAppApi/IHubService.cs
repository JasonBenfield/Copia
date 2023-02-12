using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi;

public interface IHubService
{
    public Task AddPortfolioModifier(PortfolioModel portfolio);

    public Task AssignPortfolioRoleToUser(AppUserName userName, PortfolioModel portfolio, AppRoleName roleName);
}
