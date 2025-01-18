using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApiActions.Portfolios;

public sealed record PortfolioPermissionModel(PortfolioModel Portfolio, bool CanView, bool CanEdit)
{
}
