using CopiaWebApp;
using CopiaWebApp.ApiControllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using XTI_App.Api;
using XTI_CopiaDB.Extensions;
using XTI_CopiaImplementations;
using XTI_CopiaWebAppApi;
using XTI_Core;
using XTI_HubAppClient.WebApp.Extensions;
using XTI_WebApp.Api;

var builder = XtiWebAppHost.CreateDefault(CopiaInfo.AppKey, args);
var xtiEnv = XtiEnvironment.Parse(builder.Environment.EnvironmentName);
builder.Services.ConfigureXtiCookieAndTokenAuthentication(xtiEnv, builder.Configuration);
builder.Services.AddScoped<AppApiFactory, CopiaAppApiFactory>();
builder.Services.AddScoped(sp => (CopiaAppApi)sp.GetRequiredService<IAppApi>());
builder.Services.AddCopiaAppApiServices();
builder.Services.AddCopiaDbContextForSqlServer();
builder.Services.AddScoped<IHubService, HcHubService>();
builder.Services.AddScoped<IMenuDefinitionBuilder, CopiaMenuDefinitionBuilder>();
builder.Services
    .AddMvc()
    .AddJsonOptions(options =>
    {
        options.SetDefaultJsonOptions();
    })
    .AddMvcOptions(options =>
    {
        options.SetDefaultMvcOptions();
    });
builder.Services.AddControllersWithViews()
    .PartManager.ApplicationParts.Add
    (
        new AssemblyPart(typeof(HomeController).Assembly)
    );

var app = builder.Build();
app.UseXtiDefaults();
await app.RunAsync();