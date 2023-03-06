using XTI_Copia.Abstractions;
using XTI_Core;

namespace XTI_CopiaWebAppApi.Portfolios;

internal sealed class AddPortfolioValidation : AppActionValidation<AddPortfolioRequest>
{
    public Task Validate(ErrorList errors, AddPortfolioRequest model, CancellationToken stoppingToken)
    {
        if (string.IsNullOrWhiteSpace(model.PortfolioName))
        {
            errors.Add(ValidationErrors.PortfolioNameIsRequired);
        }
        return Task.CompletedTask;
    }
}
