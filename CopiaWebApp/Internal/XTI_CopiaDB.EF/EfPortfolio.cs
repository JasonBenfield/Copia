using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfPortfolio
{
    private readonly EfCopiaDB db;
    private readonly PortfolioEntity portfolio;

    internal EfPortfolio(EfCopiaDB db, PortfolioEntity portfolio)
    {
        this.db = db;
        this.portfolio = portfolio;
    }

    public Task<EfAccount> AddAccount(string accountName, AccountType accountType) =>
        db.Accounts.AddAccount(portfolio, accountName, accountType);

    public Task<EfAccount[]> Accounts() =>
        db.Accounts.Accounts(portfolio);

    public Task<EfAccount> Account(int accountID) => db.Accounts.Account(portfolio, accountID);

    public async Task<EfActivityTemplate> AddActivityTemplate(string templateName)
    {
        var template = new ActivityTemplateEntity
        {
            TemplateName = templateName,
            PortfolioID = portfolio.ID
        };
        await db.Context.ActivityTemplates.Create(template);
        var efActivityTemplate = new EfActivityTemplate(template);
        return efActivityTemplate;
    }

    public async Task<EfActivityTemplate[]> ActivityTemplates()
    {
        var activityTemplates = await db.Context.ActivityTemplates.Retrieve()
            .Where(at => at.PortfolioID == portfolio.ID)
            .ToArrayAsync();
        return activityTemplates.Select(at => new EfActivityTemplate(at)).ToArray();
    }

    public async Task<EfActivityTemplate> ActivityTemplate(int activityTemplateID)
    {
        var activityTemplate = await db.Context.ActivityTemplates.Retrieve()
            .Where(at => at.ID == activityTemplateID && at.PortfolioID == portfolio.ID)
            .FirstOrDefaultAsync();
        return new EfActivityTemplate
        (
            activityTemplate ?? throw new Exception($"Activity Template {activityTemplateID} was not found.")
        );
    }

    public Task<EfCounterparty> AddCounterparty(string displayText, string url) =>
        db.Counterparties.Add(portfolio, displayText, url);

    public Task<EfCounterparty[]> CounterpartySearch(string searchText, int max) =>
        db.Counterparties.Search(portfolio, searchText, max);

    public Task<int> CounterpartySearchTotal(string searchText) =>
        db.Counterparties.SearchTotal(portfolio, searchText);

    public Task<EfCounterparty> Counterparty(int id) =>
        db.Counterparties.Counterparty(portfolio, id);

    public Task<EfCounterparty> CounterpartyByDisplayText(string displayText) =>
        db.Counterparties.CounterpartyByDisplayText(portfolio, displayText);

    public Task<EfCounterparty> BlankCounterparty() =>
        CounterpartyByDisplayText("");

    public async Task<EfActivity> CreateActivity(string activityName, DateTimeOffset timeCreated)
    {
        var efCounterparty = await BlankCounterparty();
        var efActivity = await db.Activities.Create
        (
            portfolio,
            activityName,
            efCounterparty,
            timeCreated
        );
        return efActivity;
    }

    public Task<EfActivity[]> Activities(int max) =>
        db.Activities.GetActivities(portfolio, max);

    public PortfolioModel ToModel() =>
        new PortfolioModel
        (
            portfolio.ID,
            portfolio.PortfolioName,
            new ModifierKey(portfolio.ID.ToString())
        );
}
