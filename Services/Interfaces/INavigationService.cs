namespace TripBudgetPlanner.Services.Interfaces;

public interface INavigationService
{
    Task NavigateToAsync(string route);
    Task NavigateBackAsync();
}
