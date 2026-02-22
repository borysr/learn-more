using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

public partial class MyAuthService
{
    private readonly IPublicClientApplication _msalClient;
    private readonly ILogger<MyAuthService> _logger;
    // The DI system automatically "injects" these when the class is created
    public MyAuthService(IPublicClientApplication msalClient, ILogger<MyAuthService> logger)
    {
        _msalClient = msalClient;
        _logger = logger;
    }
    
    public async Task RunAsync()
    {
        _logger.LogInformation("Starting authentication flow...");

        string[] scopes = { "User.Read" };

        try
        {
            var accounts = await _msalClient.GetAccountsAsync();
            var result = await _msalClient.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                .ExecuteAsync();
 
            _logger.LogInformation("Token acquired silently!");
            Console.WriteLine($"Token: {result.AccessToken}");
        }
        catch (MsalUiRequiredException)
        {
            _logger.LogWarning("Silent auth failed. Switching to interactive...");
            var result = await _msalClient.AcquireTokenInteractive(scopes).ExecuteAsync();
            Console.WriteLine($"Token: {result.AccessToken}");
        }
    }
}