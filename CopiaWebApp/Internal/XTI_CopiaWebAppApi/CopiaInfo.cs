using XTI_CopiaWebAppApiActions;

namespace XTI_CopiaWebAppApi;

public static class CopiaInfo
{
    public static readonly AppKey AppKey = CopiaAppKey.Value;

    public static readonly CopiaRoles Roles = CopiaRoles.Instance;

    public static readonly CopiaModCategories ModCategories = CopiaModCategories.Instance;
}