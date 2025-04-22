using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

internal sealed class EfAccounts
{
    private readonly EfCopiaDB db;

    internal EfAccounts(EfCopiaDB db)
    {
        this.db = db;
    }

    internal async Task<EfAccount> AddAccount(PortfolioEntity portfolio, string accountName, AccountType accountType)
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

    internal async Task<EfAccount[]> Accounts(PortfolioEntity portfolio)
    {
        var accounts = await db.Context.Accounts.Retrieve()
            .Where(a => a.PortfolioID == portfolio.ID)
            .ToArrayAsync();
        return accounts.Select(a => new EfAccount(a)).ToArray();
    }

    internal async Task<EfAccount> Account(PortfolioEntity portfolio, int accountID)
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

}
