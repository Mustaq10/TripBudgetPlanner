using System.Text.Json;
using TripBudgetPlanner.Services.Interfaces;

namespace TripBudgetPlanner.Services;

public class CurrencyConverterService : ICurrencyConverterService
{
    private readonly HttpClient _client;

    public CurrencyConverterService()
    {
        _client = new HttpClient();
    }

    public async Task<decimal> ConvertAsync(decimal amount, string fromCurrency, string toCurrency)
    {
        try
        {
            string url = $"https://open.er-api.com/v6/latest/{fromCurrency}";
            var response = await _client.GetStringAsync(url);

            var data = JsonSerializer.Deserialize<ExchangeRateResponse>(response);

            if (data == null || !data.Rates.ContainsKey(toCurrency))
                return amount;

            var rate = data.Rates[toCurrency];
            return amount * rate;
        }
        catch
        {
            return amount; // fallback
        }
    }
}

public class ExchangeRateResponse
{
    public Dictionary<string, decimal> Rates { get; set; }
}
