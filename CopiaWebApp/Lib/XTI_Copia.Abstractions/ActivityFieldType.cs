using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class ActivityFieldType : NumericValue, IEquatable<ActivityFieldType>
{
    public sealed class ActivityFieldTypes : NumericValues<ActivityFieldType>
    {
        internal ActivityFieldTypes() : base(new(0, nameof(NotSet)))
        {
            NotSet = DefaultValue;
            Counterparty = Add(new(5, nameof(Counterparty)));
            TimeOccurred = Add(new(10, nameof(TimeOccurred)));
            Amount = Add(new(15, nameof(Amount)));
        }
        public ActivityFieldType NotSet { get; }
        public ActivityFieldType Counterparty { get; }
        public ActivityFieldType TimeOccurred { get; }
        public ActivityFieldType Amount { get; }
    }

    public static readonly ActivityFieldTypes Values = new();

    private ActivityFieldType(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(ActivityFieldType? other) => _Equals(other);
}
