using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class TemplateStringPartType : NumericValue, IEquatable<TemplateStringPartType>
{
    public sealed class TemplateStringPartTypes : NumericValues<TemplateStringPartType>
    {
        internal TemplateStringPartTypes() : base(new(0, nameof(FixedText)))
        {
            FixedText = DefaultValue;
            Negative = Add(new(5, nameof(Negative)));
            Field = Add(new(10, nameof(Field)));
        }
        public TemplateStringPartType FixedText { get; }
        public TemplateStringPartType Negative { get; }
        public TemplateStringPartType Field { get; }
    }

    public static readonly TemplateStringPartTypes Values = new();

    private TemplateStringPartType(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(TemplateStringPartType? other) => _Equals(other);
}
