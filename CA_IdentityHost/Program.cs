using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IPublicClientApplication>(sp =>
{
    var clientId = builder.Configuration["AzureAd:ClientId"];
    var tenantId = builder.Configuration["AzureAd:TenantId"];
    
    return PublicClientApplicationBuilder
        .Create(clientId)
        .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
        .WithDefaultRedirectUri()
        .Build();
});

builder.Services.AddTransient<MyAuthService>();

using IHost host = builder.Build();

var authService = host.Services.GetRequiredService<MyAuthService>();
await authService.RunAsync();
