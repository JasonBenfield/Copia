using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi;

internal static class EntityExtensions
{
    public static PortfolioModel ToPortfolioModel(this PortfolioEntity portfolio) =>
        new PortfolioModel
        (
            portfolio.ID, 
            portfolio.PortfolioName, 
            new ModifierKey(portfolio.ID.ToString())
        );
}
