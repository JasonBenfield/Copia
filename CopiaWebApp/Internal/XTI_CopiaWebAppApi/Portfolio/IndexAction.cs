namespace XTI_CopiaWebAppApi.Portfolio;

internal sealed class IndexAction : AppAction<EmptyRequest, EmptyActionResult>
{
    public async Task<EmptyActionResult> Execute(EmptyRequest model, CancellationToken ct)
    {
        Console.WriteLine($"{DateTime.Now:M/dd/yy HH:mm:ss} Doing Something");
        return new EmptyActionResult();
    }
}