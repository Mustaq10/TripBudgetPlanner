using TripBudgetPlanner.ViewModels;

namespace TripBudgetPlanner.Views;

public partial class HomePage : ContentPage
{
    HomeViewModel vm;

    public HomePage()
    {
        InitializeComponent();
        vm = new HomeViewModel();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Load data & featured items
        await vm.LoadHomeData();

        // simple entrance animation for FAB (bouncy)
        FabAddTrip.Scale = 0.6;
        await Task.Delay(120);
        await FabAddTrip.ScaleTo(1.05, 220, Easing.CubicOut);
        await FabAddTrip.ScaleTo(1.0, 120, Easing.SpringOut);
    }

    private async void FabAddTrip_Clicked(object sender, EventArgs e)
    {
        // small press animation
        await FabAddTrip.ScaleTo(0.9, 80);
        await FabAddTrip.ScaleTo(1.0, 120, Easing.SpringOut);

        // navigate to AddTrip page
        await Shell.Current.GoToAsync(nameof(Views.AddTripPage));
    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        // simple settings navigation (replace route with your settings page if you have one)
        await Shell.Current.GoToAsync("settings");
    }
}
