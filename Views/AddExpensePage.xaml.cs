using TripBudgetPlanner.ViewModels;

namespace TripBudgetPlanner.Views;

[QueryProperty(nameof(TripId), "tripId")]
public partial class AddExpensePage : ContentPage
{
    public int TripId { get; set; }

    public AddExpensePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new AddExpenseViewModel { TripId = TripId };
    }
}
