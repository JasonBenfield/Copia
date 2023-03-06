using XTI_Copia.Abstractions;
using XTI_Core;

namespace XTI_CopiaWebAppApi.Portfolio;

internal sealed class AddAccountValidation : AppActionValidation<AddAccountForm>
{
    public Task Validate(ErrorList errors, AddAccountForm model, CancellationToken stoppingToken)
    {
        var accountType = model.AccountType.Value();
        if((accountType ?? 0) == 0)
        {
            errors.Add(ValidationErrors.AccountTypeIsRequired);
        }
        return Task.CompletedTask;
    }
}
