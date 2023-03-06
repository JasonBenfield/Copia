using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class AccountType : NumericValue, IEquatable<AccountType>
{
    public sealed class AccountTypes : NumericValues<AccountType>
    {
        internal AccountTypes() : base(new(0, nameof(NotSet)))
        {
            NotSet = DefaultValue;
            Checking = Add(new(5, nameof(Checking)));
            Savings = Add(new(10, nameof(Savings)));
            CreditCard = Add(new(15, nameof(CreditCard)));
            MoneyMarket = Add(new(20, nameof(MoneyMarket)));
        }
        public AccountType NotSet { get; }
        public AccountType Checking { get; }
        public AccountType Savings { get; }
        public AccountType CreditCard { get; }
        public AccountType MoneyMarket { get; }
    }

    public static readonly AccountTypes Values = new();

    private AccountType(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(AccountType? other) => _Equals(other);
}
