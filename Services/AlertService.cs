using TripBudgetPlanner.Services.Interfaces;

namespace TripBudgetPlanner.Services;

public class AlertService : IAlertService
{
    public Task ShowAlertAsync(string title, string message, string buttonText = "OK")
    {
        return Shell.Current.DisplayAlert(title, message, buttonText);
    }
}
