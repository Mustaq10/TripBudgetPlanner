namespace TripBudgetPlanner.Services.Interfaces;

public interface ICurrencyConverterService
{
    Task<decimal> ConvertAsync(decimal amount, string fromCurrency, string toCurrency);
}
