using XTI_Core;

namespace XTI_Copia.Abstractions;

public sealed class ActivityFieldAccessibility : NumericValue, IEquatable<ActivityFieldAccessibility>
{
    public sealed class ActivityFieldAccessibilities : NumericValues<ActivityFieldAccessibility>
    {
        public ActivityFieldAccessibilities() : base(new(0, nameof(Editable)))
        {
            Editable = DefaultValue;
            ReadOnly = Add(new(5, nameof(ReadOnly)));
            Hidden = Add(new(10, nameof(Hidden)));
        }
        public ActivityFieldAccessibility Editable { get; }
        public ActivityFieldAccessibility ReadOnly { get; }
        public ActivityFieldAccessibility Hidden { get; }
    }

    public static ActivityFieldAccessibilities Values = new();

    private ActivityFieldAccessibility(int value, string displayText) : base(value, displayText)
    {
    }

    public bool Equals(ActivityFieldAccessibility? other) => _Equals(other);
}
