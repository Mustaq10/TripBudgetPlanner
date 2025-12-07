using TripBudgetPlanner.ViewModels;

namespace TripBudgetPlanner.Views;

public partial class TripListPage : ContentPage
{
    private TripListViewModel Vm => BindingContext as TripListViewModel;

    public TripListPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (Vm != null)
        {
            await Vm.LoadTrips();
        }
    }
}
