using XTI_App.Abstractions;
using XTI_CopiaWebAppApi;
using XTI_WebApp.Api;

namespace CopiaWebApp;

internal sealed class CopiaMenuDefinitionBuilder : IMenuDefinitionBuilder
{
    private readonly UserMenuDefinition userMenuDefinition;
    private readonly CopiaAppApi api;

    public CopiaMenuDefinitionBuilder(UserMenuDefinition userMenuDefinition, CopiaAppApi api)
    {
        this.userMenuDefinition = userMenuDefinition;
        this.api = api;
    }

    public AppMenuDefinitions Build() =>
        new AppMenuDefinitions
        (
            userMenuDefinition.Value,
            new MenuDefinition
            (
                "main",
                new LinkModel("main", "Portfolios", api.Portfolios.Index.Path.RootPath())
            )
        );
}


