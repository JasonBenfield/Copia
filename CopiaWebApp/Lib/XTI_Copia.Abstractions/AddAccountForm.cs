using XTI_Core;
using XTI_Forms;

namespace XTI_Copia.Abstractions;

public sealed class AddAccountForm : Form
{
    public AddAccountForm() : base(nameof(AddAccountForm))
    {
        AccountName = AddTextInput(nameof(AccountName));
        AccountName.MaxLength = 500;
        AccountName.MustNotBeNull();
        AccountName.MustNotBeWhiteSpace();
        AccountType = AddInt32DropDown(nameof(AccountType));
        AccountType.MustNotBeNull();
        AccountType.AddItems
        (
            Abstractions.AccountType.Values.GetAll()
                .Where(t=>t.Value > 0)
                .Select(t=>new DropDownItem<int?>(t.Value, t.DisplayText))
                .ToArray()
        );
    }
    public InputField<string> AccountName { get; }
    [NumericValue(typeof(AccountType))]
    public DropDownField<int?> AccountType { get; }
}
