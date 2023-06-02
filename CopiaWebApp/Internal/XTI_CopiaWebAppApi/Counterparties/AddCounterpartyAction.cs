using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.Counterparties;

internal sealed class AddCounterpartyAction : AppAction<AddCounterpartyForm, CounterpartyModel>
{
    private readonly CopiaDbContext db;

    public async Task<CounterpartyModel> Execute(AddCounterpartyForm model, CancellationToken stoppingToken)
    {
        return new CounterpartyModel();
    }
}
