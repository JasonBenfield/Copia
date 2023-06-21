using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfPortfolio
{
    private readonly CopiaDbContext db;
    private readonly PortfolioEntity portfolio;

    internal EfPortfolio(CopiaDbContext db, PortfolioEntity entity)
    {
        this.db = db;
        this.portfolio = entity;
    }

    public async Task<EfAccount> AddAccount(string accountName, AccountType accountType)
    {
        var account = new AccountEntity
        {
            AccountName = accountName,
            AccountType = accountType,
            PortfolioID = portfolio.ID
        };
        await db.Accounts.Create(account);
        return new EfAccount(account);
    }

    public async Task<EfAccount[]> Accounts()
    {
        var accounts = await db.Accounts.Retrieve()
            .Where(a => a.PortfolioID == portfolio.ID)
            .ToArrayAsync();
        return accounts.Select(a => new EfAccount(a)).ToArray();
    }

    public async Task<EfAccount> Account(int accountID)
    {
        var account = await db.Accounts.Retrieve()
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
        var efActivityName = await AddTemplateString(true, TemplateStringDataType.Values.String);
        var template = new ActivityTemplateEntity
        {
            TemplateName = templateName,
            PortfolioID = portfolio.ID,
            ActivityNameTemplateStringID = efActivityName.ID
        };
        await db.ActivityTemplates.Create(template);
        var efActivityTemplate = new EfActivityTemplate(db, this, template);
        var fieldTypes = ActivityFieldType.Values.GetAll()
            .Where(ft => !ft.Equals(ActivityFieldType.Values.NotSet))
            .ToArray();
        foreach (var fieldType in fieldTypes)
        {
            await efActivityTemplate.AddTemplateField(template.ID, fieldType);
        }
        return efActivityTemplate;
    }

    private async Task<EfTemplateString> AddTemplateString(bool canEdit, TemplateStringDataType dataType)
    {
        var templateString = new TemplateStringEntity
        {
            PortfolioID = portfolio.ID,
            CanEdit = canEdit,
            DataType = dataType
        };
        await db.TemplateStrings.Create(templateString);
        return new EfTemplateString(db, templateString);
    }

    public async Task<EfTemplateString> TemplateString(int templateStringID)
    {
        var templateString = await db.TemplateStrings.Retrieve()
            .Where(ts => ts.ID == templateStringID && ts.PortfolioID == portfolio.ID)
            .FirstOrDefaultAsync();
        return new EfTemplateString(db, templateString ?? throw new Exception($"Template String {templateStringID} was not found."));
    }

    public async Task<EfActivityTemplate[]> ActivityTemplates()
    {
        var activityTemplates = await db.ActivityTemplates.Retrieve()
            .Where(at => at.PortfolioID == portfolio.ID)
            .ToArrayAsync();
        return activityTemplates.Select(at => new EfActivityTemplate(db, this, at)).ToArray();
    }

    public async Task<EfActivityTemplate> ActivityTemplate(int activityTemplateID)
    {
        var activityTemplate = await db.ActivityTemplates.Retrieve()
            .Where(at => at.ID == activityTemplateID && at.PortfolioID == portfolio.ID)
            .FirstOrDefaultAsync();
        return new EfActivityTemplate
        (
            db,
            this,
            activityTemplate ?? throw new Exception($"Activity Template {activityTemplateID} was not found.")
        );
    }

    public Task<EfCounterparty> AddCounterparty(string displayText, string url) =>
        new EfCounterparties(db).Add(portfolio, displayText, url);

    public Task<EfCounterparty[]> CounterpartySearch(string searchText, int max) =>
        new EfCounterparties(db).Search(portfolio, searchText, max);

    public Task<int> CounterpartySearchTotal(string searchText) =>
        new EfCounterparties(db).SearchTotal(portfolio, searchText);

    public Task<EfCounterparty> Counterparty(int id) =>
        new EfCounterparties(db).Counterparty(portfolio, id);

    public Task<EfCounterparty> CounterpartyByDisplayText(string displayText) =>
        new EfCounterparties(db).CounterpartyByDisplayText(portfolio, displayText);

    public Task<EfCounterparty> BlankCounterparty() =>
        CounterpartyByDisplayText("");

    public async Task<EfActivity> CreateActivity(EfActivityTemplate efTemplate, DateTimeOffset timeCreated)
    {
        var efCounterparty = await BlankCounterparty();
        var efActivity = await new EfActivities(db).Create
        (
            portfolio,
            efTemplate,
            efCounterparty,
            timeCreated
        );
        return efActivity;
    }

    public Task<EfActivity[]> Activities(int max) => 
        new EfActivities(db).GetActivities(portfolio, max);

    public PortfolioModel ToModel() =>
        new PortfolioModel
        (
            portfolio.ID,
            portfolio.PortfolioName,
            new ModifierKey(portfolio.ID.ToString())
        );
}
