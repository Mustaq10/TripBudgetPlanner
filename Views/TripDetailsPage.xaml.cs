using TripBudgetPlanner.ViewModels;

namespace TripBudgetPlanner.Views;

[QueryProperty(nameof(TripId), "tripId")]
public partial class TripDetailsPage : ContentPage
{
    public int TripId { get; set; }
    TripDetailsViewModel vm;

    public TripDetailsPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        vm = new TripDetailsViewModel(TripId);
        BindingContext = vm;

        await vm.LoadData();
    }
}
