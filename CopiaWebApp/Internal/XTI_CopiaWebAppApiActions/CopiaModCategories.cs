namespace XTI_CopiaWebAppApiActions;

public sealed class CopiaModCategories
{
    public static readonly CopiaModCategories Instance = new();

    public ModifierCategoryName Portfolio { get; } = new(nameof(Portfolio));
}
