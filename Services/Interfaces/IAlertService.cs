namespace TripBudgetPlanner.Services.Interfaces;

public interface IAlertService
{
    Task ShowAlertAsync(string title, string message, string buttonText = "OK");
}
