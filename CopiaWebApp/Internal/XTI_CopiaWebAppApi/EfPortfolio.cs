using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi;

internal sealed class EfPortfolio
{
    private readonly CopiaDbContext db;
    private readonly PortfolioEntity entity;

    public EfPortfolio(CopiaDbContext db, PortfolioEntity entity)
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
        if(account == null)
        {
            throw new Exception($"Account {accountID} was not found.");
        }
        if(account.PortfolioID != entity.ID)
        {
            throw new Exception(string.Format(CopiaErrors.AccountDoesNotBelongToPortfolio, accountID, entity.ID));
        }
        return new EfAccount(account);
    }

    public PortfolioModel ToModel() =>
        new PortfolioModel
        (
            entity.ID,
            entity.PortfolioName,
            new ModifierKey(entity.ID.ToString())
        );
}
