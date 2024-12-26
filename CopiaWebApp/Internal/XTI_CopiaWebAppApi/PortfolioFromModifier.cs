using XTI_CopiaDB;
using XTI_Core;

namespace XTI_CopiaWebAppApi;

internal sealed class PortfolioFromModifier
{
    private readonly IModifierKeyAccessor modifierKeyAccessor;
    private readonly EfPortfolios efPortfolios;

    public PortfolioFromModifier(IModifierKeyAccessor modifierKeyAccessor, CopiaDbContext db)
    {
        this.modifierKeyAccessor = modifierKeyAccessor;
        efPortfolios = new EfPortfolios(db);
    }

    public Task<EfPortfolio> Value()
    {
        var modKey = modifierKeyAccessor.Value();
        if (modKey.Equals(ModifierKey.Default))
        {
            throw new ValidationFailedException([new ErrorModel(ValidationErrors.PortfolioModifierIsRequired)]);
        }
        return efPortfolios.Portfolio(modKey);
    }
}
