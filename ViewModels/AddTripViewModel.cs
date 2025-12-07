using System.Windows.Input;
using TripBudgetPlanner.Models;

namespace TripBudgetPlanner.ViewModels;

public class AddTripViewModel : BaseViewModel
{
    private string _name;
    private decimal _budget;
    private DateTime _startDate = DateTime.Today;
    private DateTime _endDate = DateTime.Today.AddDays(1);

    public AddTripViewModel()
    {
        SaveTripCommand = new Command(async () => await SaveTrip());
    }

    public ICommand SaveTripCommand { get; }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    // Make budget nullable so empty Entry does NOT cause conversion warnings
    private decimal? _budgetNullable;

    public decimal? Budget
    {
        get => _budgetNullable;
        set => SetProperty(ref _budgetNullable, value);
    }

    public DateTime StartDate
    {
        get => _startDate;
        set => SetProperty(ref _startDate, value);
    }

    public DateTime EndDate
    {
        get => _endDate;
        set => SetProperty(ref _endDate, value);
    }

    public async Task SaveTrip()
    {
        if (string.IsNullOrWhiteSpace(Name) || Budget == null || Budget <= 0)
        {
            await Shell.Current.DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        }

        var trip = new Trip
        {
            Name = Name,
            Budget = Budget.Value,
            StartDate = StartDate,
            EndDate = EndDate
        };

        await App.Database.AddTrip(trip);
        await Shell.Current.GoToAsync("..");
    }
}
