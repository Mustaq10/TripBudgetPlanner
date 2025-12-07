using System.Collections.ObjectModel;
using TripBudgetPlanner.Models;

namespace TripBudgetPlanner.ViewModels;

public class TripDetailsViewModel : BaseViewModel
{
    public int TripId { get; private set; }

    private Trip _trip;
    public Trip Trip
    {
        get => _trip;
        set => SetProperty(ref _trip, value);
    }

    public ObservableCollection<Expense> Expenses { get; set; } = new();

    public Command AddExpenseCommand { get; }
    public Command<Expense> DeleteExpenseCommand { get; }

    public TripDetailsViewModel(int tripId)
    {
        TripId = tripId;

        AddExpenseCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync($"{nameof(Views.AddExpensePage)}?tripId={TripId}");
        });

        DeleteExpenseCommand = new Command<Expense>(async (exp) =>
        {
            await DeleteExpense(exp);
        });
    }

    public async Task LoadData()
    {
        IsBusy = true;

        Trip = await App.Database.GetTripById(TripId);

        Expenses.Clear();
        var items = await App.Database.GetExpensesByTrip(TripId);
        foreach (var e in items)
            Expenses.Add(e);

        IsBusy = false;
    }

    private async Task DeleteExpense(Expense expense)
    {
        if (expense == null)
            return;

        bool confirm = await Shell.Current.DisplayAlert(
            "Delete Expense",
            $"Are you sure you want to delete \"{expense.Description}\"?",
            "Delete", "Cancel");

        if (!confirm)
            return;

        await App.Database.DeleteExpense(expense);

        // Remove from UI instantly
        Expenses.Remove(expense);
    }
}
