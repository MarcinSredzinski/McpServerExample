using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace McpServerExample.Tools;

[McpServerToolType]
internal class DotnetFoundationRepositoryReporter
{
    [McpServerTool(Name = "GetDotnetFoundationRepositories")]
    [Description("Fetches repositories from the .NET Foundation GitHub organization.")]
    internal async Task<string> GetDotnetFoundationRepositories()
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("User-Agent", "McpServerExample");
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        var json = await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
        return json;
    }
}