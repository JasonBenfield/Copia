using XTI_Core;

namespace XTI_CopiaWebAppApiActions;

public sealed class PortfolioFromModifier
{
    private readonly IModifierKeyAccessor modifierKeyAccessor;
    private readonly EfCopiaDB db;

    public PortfolioFromModifier(IModifierKeyAccessor modifierKeyAccessor, EfCopiaDB db)
    {
        this.modifierKeyAccessor = modifierKeyAccessor;
        this.db = db;
    }

    public Task<EfPortfolio> Value()
    {
        var modKey = modifierKeyAccessor.Value();
        if (modKey.Equals(ModifierKey.Default))
        {
            throw new ValidationFailedException([new ErrorModel(ValidationErrors.PortfolioModifierIsRequired)]);
        }
        return db.Portfolios.Portfolio(modKey);
    }
}
