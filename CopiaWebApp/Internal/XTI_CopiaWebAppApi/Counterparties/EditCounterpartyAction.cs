using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Counterparties;

internal sealed class EditCounterpartyAction : AppAction<EditCounterpartyForm, CounterpartyModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public EditCounterpartyAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<CounterpartyModel> Execute(EditCounterpartyForm editForm, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var displayText = editForm.DisplayText.Value() ?? "";
        var efCounterparty = await efPortfolio.Counterparty(editForm.CounterpartyID.Value() ?? 0);
        var existingCounterparty = await efPortfolio.CounterpartyByDisplayText(displayText);
        if (existingCounterparty.IsFound() && !existingCounterparty.HasSameID(efCounterparty))
        {
            throw new AppException(ValidationErrors.CounterpartyAlreadyExists);
        }
        await efCounterparty.Edit(editForm);
        return efCounterparty.ToModel();
    }
}
