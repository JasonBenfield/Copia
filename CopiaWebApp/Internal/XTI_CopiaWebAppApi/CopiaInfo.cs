namespace XTI_CopiaWebAppApi;

public static class CopiaInfo
{
    public static readonly AppKey AppKey = AppKey.WebApp("Copia");

    public static readonly CopiaRoles Roles = CopiaRoles.Instance;

    public static class ModCategories
    {
        public static readonly ModifierCategoryName Portfolio = new(nameof(Portfolio));
    }
}