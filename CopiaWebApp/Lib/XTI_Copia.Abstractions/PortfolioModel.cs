using XTI_App.Abstractions;

namespace XTI_Copia.Abstractions;

public sealed record PortfolioModel(int ID, string PortfolioName, ModifierKey PublicKey)
{
    public PortfolioModel()
        : this(0, "", ModifierKey.Default)
    {
    }
}