using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class TemplateStringDataType : NumericValue, IEquatable<TemplateStringDataType>
{
    public sealed class TemplateStringDataTypes : NumericValues<TemplateStringDataType>
    {
        internal TemplateStringDataTypes() : base(new(0, nameof(NotSet)))
        {
            NotSet = DefaultValue;
            String = Add(new(5, nameof(String)));
            Decimal = Add(new(10, nameof(Decimal)));
            DateTimeOffset = Add(new(15, nameof(DateTimeOffset)));
        }
        public TemplateStringDataType NotSet { get; }
        public TemplateStringDataType String { get; }
        public TemplateStringDataType Decimal { get; }
        public TemplateStringDataType DateTimeOffset { get; }
    }

    public static readonly TemplateStringDataTypes Values = new();

    private TemplateStringDataType(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(TemplateStringDataType? other) => _Equals(other);
}
