using TripBudgetPlanner.ViewModels;

namespace TripBudgetPlanner.Views;

public partial class AddTripPage : ContentPage
{
    public AddTripPage()
    {
        InitializeComponent();
        BindingContext = new AddTripViewModel();
    }
}
