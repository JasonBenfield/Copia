using XTI_Forms;

namespace XTI_Copia.Abstractions;

public sealed class AddCounterpartyForm : Form
{
    public AddCounterpartyForm() : base(nameof(AddCounterpartyForm))
    {
        DisplayText = AddTextInput(nameof(DisplayText));
        DisplayText.MustNotBeNull();
        DisplayText.MustNotBeWhiteSpace();
        DisplayText.MaxLength = 500;
        Url = AddTextInput(nameof(Url));
        Url.MustNotBeNull();
        Url.MaxLength = 500;
    }

    public InputField<string> DisplayText { get; }
    public InputField<string> Url { get; }
}
