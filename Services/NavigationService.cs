using TripBudgetPlanner.Services.Interfaces;

namespace TripBudgetPlanner.Services;

public class NavigationService : INavigationService
{
    public Task NavigateToAsync(string route)
    {
        return Shell.Current.GoToAsync(route);
    }

    public Task NavigateBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}
