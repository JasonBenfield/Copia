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
        createAccountGroup(sp);
        createActivityTemplateGroup(sp);
        createActivityTemplatesGroup(sp);
        createHomeGroup(sp);
        createPortfolioGroup(sp);
        createPortfoliosGroup(sp);
    }

    partial void createAccountGroup(IServiceProvider sp);

    partial void createActivityTemplateGroup(IServiceProvider sp);

    partial void createActivityTemplatesGroup(IServiceProvider sp);

    partial void createHomeGroup(IServiceProvider sp);

    partial void createPortfolioGroup(IServiceProvider sp);

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