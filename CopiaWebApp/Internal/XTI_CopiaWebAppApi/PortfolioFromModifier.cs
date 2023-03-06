using XTI_CopiaDB;
using XTI_Core;

namespace XTI_CopiaWebAppApi;

internal sealed class PortfolioFromModifier
{
    private readonly IXtiPathAccessor pathAccessor;
    private readonly EfPortfolios efPortfolios;

    public PortfolioFromModifier(IXtiPathAccessor pathAccessor, CopiaDbContext db)
    {
        this.pathAccessor = pathAccessor;
        efPortfolios = new EfPortfolios(db);
    }

    public Task<EfPortfolio> Value()
    {
        var path = pathAccessor.Value();
        if (path.Modifier.Equals(ModifierKey.Default))
        {
            throw new ValidationFailedException(new[] { new ErrorModel(ValidationErrors.PortfolioModifierIsRequired) });
        }
        return efPortfolios.Portfolio(path.Modifier);
    }
}
