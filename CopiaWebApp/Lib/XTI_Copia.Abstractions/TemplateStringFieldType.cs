using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class TemplateStringFieldType : NumericValue, IEquatable<TemplateStringFieldType>
{
    public sealed class ActivityTemplateStringFieldTypes : NumericValues<TemplateStringFieldType>
    {
        internal ActivityTemplateStringFieldTypes() : base(new(0, nameof(NotSet)))
        {
            NotSet = DefaultValue;
            Amount = Add(new(5, nameof(Amount)));
            CounterpartyID = Add(new(10, nameof(CounterpartyID)));
            CounterpartyName = Add(new(15, nameof(CounterpartyName)));
            AccountID = Add(new(20, nameof(AccountID)));
            AccountName = Add(new(25, nameof(AccountName)));
        }
        public TemplateStringFieldType NotSet { get; }
        public TemplateStringFieldType Amount { get; }
        public TemplateStringFieldType CounterpartyID { get; }
        public TemplateStringFieldType CounterpartyName { get; }
        public TemplateStringFieldType AccountID { get; }
        public TemplateStringFieldType AccountName { get; }
    }

    public static readonly ActivityTemplateStringFieldTypes Values = new();

    private TemplateStringFieldType(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(TemplateStringFieldType? other) => _Equals(other);
}
