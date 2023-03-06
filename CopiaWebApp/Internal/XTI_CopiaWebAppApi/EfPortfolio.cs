using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi;

internal sealed class EfPortfolio
{
    private readonly PortfolioEntity entity;

    public EfPortfolio(PortfolioEntity entity)
    {
        this.entity = entity;
    }

    public PortfolioModel ToModel() =>
        new PortfolioModel
        (
            entity.ID,
            entity.PortfolioName,
            new ModifierKey(entity.ID.ToString())
        );
}
