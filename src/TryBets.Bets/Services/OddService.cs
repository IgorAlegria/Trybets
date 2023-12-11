using System.Net.Http;
using System.Text;
namespace TryBets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        var URL = $"https://localhost:5504/odd/{MatchId}/{TeamId}/{BetValue}";

        var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

        var response = await _client.PatchAsync(URL, content);

        if (response.IsSuccessStatusCode)
        {
            return content;
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            return errorMessage;
        }
    }
}