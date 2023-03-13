using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfPortfolio
{
    private readonly CopiaDbContext db;
    private readonly PortfolioEntity entity;

    internal EfPortfolio(CopiaDbContext db, PortfolioEntity entity)
    {
        this.db = db;
        this.entity = entity;
    }

    public async Task<EfAccount> AddAccount(string accountName, AccountType accountType)
    {
        var account = new AccountEntity
        {
            AccountName = accountName,
            AccountType = accountType,
            PortfolioID = entity.ID
        };
        await db.Accounts.Create(account);
        return new EfAccount(account);
    }

    public async Task<EfAccount[]> Accounts()
    {
        var accounts = await db.Accounts.Retrieve()
            .Where(a => a.PortfolioID == entity.ID)
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
        if (account.PortfolioID != entity.ID)
        {
            throw new Exception(string.Format(CopiaDBErrors.AccountDoesNotBelongToPortfolio, accountID, entity.ID));
        }
        return new EfAccount(account);
    }

    public async Task<EfActivityTemplate> AddActivityTemplate(string templateName)
    {
        var efActivityName = await AddTemplateString(true, TemplateStringDataType.Values.String);
        var template = new ActivityTemplateEntity
        {
            TemplateName = templateName,
            PortfolioID = entity.ID,
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
            PortfolioID = entity.ID,
            CanEdit = canEdit,
            DataType = dataType
        };
        await db.TemplateStrings.Create(templateString);
        return new EfTemplateString(db, templateString);
    }

    public async Task<EfTemplateString> TemplateString(int templateStringID)
    {
        var templateString = await db.TemplateStrings.Retrieve()
            .Where(ts => ts.ID == templateStringID && ts.PortfolioID == entity.ID)
            .FirstOrDefaultAsync();
        return new EfTemplateString(db, templateString ?? throw new Exception($"Template String {templateStringID} was not found."));
    }

    public async Task<EfActivityTemplate[]> ActivityTemplates()
    {
        var activityTemplates = await db.ActivityTemplates.Retrieve()
            .Where(at => at.PortfolioID == entity.ID)
            .ToArrayAsync();
        return activityTemplates.Select(at => new EfActivityTemplate(db, this, at)).ToArray();
    }

    public async Task<EfActivityTemplate> ActivityTemplate(int activityTemplateID)
    {
        var activityTemplate = await db.ActivityTemplates.Retrieve()
            .Where(at => at.ID == activityTemplateID && at.PortfolioID == entity.ID)
            .FirstOrDefaultAsync();
        return new EfActivityTemplate(db, this, activityTemplate ?? throw new Exception($"Activity Template {activityTemplateID} was not found."));
    }

    public PortfolioModel ToModel() =>
        new PortfolioModel
        (
            entity.ID,
            entity.PortfolioName,
            new ModifierKey(entity.ID.ToString())
        );
}
