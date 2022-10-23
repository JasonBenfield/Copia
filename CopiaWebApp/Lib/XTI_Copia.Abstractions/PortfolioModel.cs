namespace XTI_Copia.Abstractions;

public sealed record PortfolioModel(int ID, string PortfolioName)
{
    public PortfolioModel()
        : this(0, "")
    {
    }
}