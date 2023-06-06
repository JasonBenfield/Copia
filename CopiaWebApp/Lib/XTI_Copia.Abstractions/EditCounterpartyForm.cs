using XTI_Forms;

namespace XTI_Copia.Abstractions;

public sealed class EditCounterpartyForm : Form
{
    public EditCounterpartyForm() : base(nameof(EditCounterpartyForm))
    {
        CounterpartyID = AddInt32Hidden(nameof(CounterpartyID));
        CounterpartyID.MustBePositive();
        DisplayText = AddTextInput(nameof(DisplayText));
        DisplayText.MustNotBeNull();
        DisplayText.MustNotBeWhiteSpace();
        DisplayText.MaxLength = 500;
        Url = AddTextInput(nameof(Url));
        Url.MustNotBeNull();
        Url.MaxLength = 500;
    }

    public HiddenField<int?> CounterpartyID { get; }
    public InputField<string> DisplayText { get; }
    public InputField<string> Url { get; }
}
