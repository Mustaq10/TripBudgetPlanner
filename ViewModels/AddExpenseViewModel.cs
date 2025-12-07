using TripBudgetPlanner.Models;
using System.Collections.ObjectModel;

namespace TripBudgetPlanner.ViewModels;

public class AddExpenseViewModel : BaseViewModel
{
    public int TripId { get; set; }

    private string _description;
    private decimal _amount;

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public decimal Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    public ObservableCollection<string> Categories { get; set; } =
        new ObservableCollection<string>
        {
            "Travel",
            "Food",
            "Hotel",
            "Shopping",
            "Fuel",
            "Tickets",
            "Entertainment",
            "General"
        };

    private string _selectedCategory = "General";
    public string SelectedCategory
    {
        get => _selectedCategory;
        set => SetProperty(ref _selectedCategory, value);
    }

    public Command SaveExpenseCommand { get; }

    public AddExpenseViewModel()
    {
        SaveExpenseCommand = new Command(async () => await SaveExpense());
    }

    private async Task SaveExpense()
    {
        if (string.IsNullOrWhiteSpace(Description) || Amount <= 0)
        {
            await Shell.Current.DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        }

        var expense = new Expense
        {
            TripId = TripId,
            Description = Description,
            Amount = Amount,
            CreatedOn = DateTime.Now,
            Category = SelectedCategory   // <--- FIXED
        };

        await App.Database.AddExpense(expense);

        await Shell.Current.GoToAsync("..");
    }
}
