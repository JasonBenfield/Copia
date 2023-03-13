using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class TemplateStringArrayType : NumericValue, IEquatable<TemplateStringArrayType>
{
    public sealed class TemplateStringArrayTypes : NumericValues<TemplateStringArrayType>
    {
        internal TemplateStringArrayTypes() : base(new(0, nameof(NotSet)))
        {
            NotSet = DefaultValue;
            Transactions = Add(new(5, nameof(Transactions)));
        }
        public TemplateStringArrayType NotSet { get; }
        public TemplateStringArrayType Transactions { get; }
    }

    public static readonly TemplateStringArrayTypes Values = new();

    private TemplateStringArrayType(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(TemplateStringArrayType? other) => _Equals(other);
}
