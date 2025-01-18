namespace XTI_Copia.Abstractions;

public sealed class AddPortfolioRequest
{
    public AddPortfolioRequest()
        : this("")
    {
    }

    public AddPortfolioRequest(string portfolioName)
    {
        PortfolioName = portfolioName;
    }

    public string PortfolioName { get; set; }
}