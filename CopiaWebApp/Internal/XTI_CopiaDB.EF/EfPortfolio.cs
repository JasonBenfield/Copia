using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;
using XTI_Forms;

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

    public async Task<EfAccount> AddAccount(string accountName, AccountType accountType)
    {
        var account = new AccountEntity
        {
            AccountName = accountName,
            AccountType = accountType,
            PortfolioID = portfolio.ID
        };
        await db.Context.Accounts.Create(account);
        return new EfAccount(account);
    }

    public async Task<EfAccount[]> Accounts()
    {
        var accounts = await db.Context.Accounts.Retrieve()
            .Where(a => a.PortfolioID == portfolio.ID)
            .ToArrayAsync();
        return accounts.Select(a => new EfAccount(a)).ToArray();
    }

    public async Task<EfAccount> Account(int accountID)
    {
        var account = await db.Context.Accounts.Retrieve()
            .Where(a => a.ID == accountID)
            .FirstOrDefaultAsync();
        if (account == null)
        {
            throw new Exception(string.Format(CopiaDBErrors.AccountIDNotFound, accountID));
        }
        if (account.PortfolioID != portfolio.ID)
        {
            throw new Exception(string.Format(CopiaDBErrors.AccountDoesNotBelongToPortfolio, accountID, portfolio.ID));
        }
        return new EfAccount(account);
    }

    public async Task<EfActivityTemplate> AddActivityTemplate(string templateName)
    {
        var template = new ActivityTemplateEntity
        {
            TemplateName = templateName,
            PortfolioID = portfolio.ID
        };
        await db.Context.ActivityTemplates.Create(template);
        var efActivityTemplate = new EfActivityTemplate( template);
        return efActivityTemplate;
    }

    public async Task<EfActivityTemplate[]> ActivityTemplates()
    {
        var activityTemplates = await db.Context.ActivityTemplates.Retrieve()
            .Where(at => at.PortfolioID == portfolio.ID)
            .ToArrayAsync();
        return activityTemplates.Select(at => new EfActivityTemplate( at)).ToArray();
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

    public async Task<EfActivity> CreateActivity(EfActivityTemplate efTemplate, DateTimeOffset timeCreated)
    {
        var efCounterparty = await BlankCounterparty();
        var efActivity = await db.Activities.Create
        (
            portfolio,
            efTemplate,
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
