using XTI_Copia.Abstractions;
using XTI_Core;

namespace XTI_CopiaWebAppApi.ActivityTemplates;

internal sealed class AddActivityTemplateValidation : AppActionValidation<AddActivityTemplateRequest>
{
    public Task Validate(ErrorList errors, AddActivityTemplateRequest model, CancellationToken stoppingToken)
    {
        if (string.IsNullOrWhiteSpace(model.TemplateName))
        {
            errors.Add(ValidationErrors.ActivityTemplateNameIsRequired);
        }
        return Task.CompletedTask;
    }
}
