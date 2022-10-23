namespace XTI_CopiaWebAppApi;

public sealed partial class CopiaAppApi : WebAppApiWrapper
{
    public CopiaAppApi
    (
        IAppApiUser user,
        IServiceProvider sp
    )
        : base
        (
            new AppApi
            (
                CopiaInfo.AppKey,
                user,
                ResourceAccess.AllowAuthenticated()
                    .WithAllowed(AppRoleName.Admin)
            ),
            sp
        )
    {
        createHomeGroup(sp);
        createPortfoliosGroup(sp);
    }

    partial void createHomeGroup(IServiceProvider sp);

    partial void createPortfoliosGroup(IServiceProvider sp);

    protected override void ConfigureTemplate(AppApiTemplate template)
    {
        base.ConfigureTemplate(template);
        template.ExcludeValueTemplates
        (
            (valueTempl, codeGen) =>
            {
                if(codeGen == ApiCodeGenerators.Dotnet)
                {
                    return valueTempl.DataType.Namespace?.StartsWith("XTI_Copia.Abstractions") == true;
                }
                return false;
            }
        );
    }
}