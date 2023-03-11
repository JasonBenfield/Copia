﻿using XTI_CopiaWebAppApi.Portfolio;

namespace XTI_CopiaWebAppApi;

internal static class PortfolioGroupExtensions
{
    public static void AddPortfolioGroupServices(this IServiceCollection services)
    {
        services.AddScoped<PortfolioFromModifier>();
        services.AddScoped<IndexAction>();
        services.AddScoped<AddAccountAction>();
        services.AddScoped<AddAccountValidation>();
        services.AddScoped<GetAccountsAction>();
        services.AddScoped<GetPortfolioAction>();
    }
}