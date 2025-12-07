using TripBudgetPlanner.ViewModels;

namespace TripBudgetPlanner.Views;

public partial class DashboardPage : ContentPage
{
    DashboardViewModel vm;

    public DashboardPage()
    {
        InitializeComponent();
        vm = new DashboardViewModel();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadDashboard();
    }
}
