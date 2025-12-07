using System.Collections.ObjectModel;
using TripBudgetPlanner.Models;

namespace TripBudgetPlanner.ViewModels;

public class HomeViewModel : BaseViewModel
{
    // Greeting uses the user's name (from your project context)
    public string Greeting => $"Hello, Globe Trotter !!!";

    // Stats
    private int _totalTrips;
    public int TotalTrips { get => _totalTrips; set => SetProperty(ref _totalTrips, value); }

    private decimal _totalExpenses;
    public decimal TotalExpenses { get => _totalExpenses; set => SetProperty(ref _totalExpenses, value); }

    private decimal _totalBudget;
    public decimal TotalBudget { get => _totalBudget; set => SetProperty(ref _totalBudget, value); }

    // Recent trips
    public ObservableCollection<Trip> RecentTrips { get; } = new();
    private Trip _selectedRecentTrip;
    public Trip SelectedRecentTrip
    {
        get => _selectedRecentTrip;
        set
        {
            if (SetProperty(ref _selectedRecentTrip, value) && value != null)
            {
                // Navigate to TripDetailsPage
                Shell.Current.GoToAsync($"{nameof(Views.TripDetailsPage)}?tripId={value.Id}");

                // Clear selection so you can click again
                SelectedRecentTrip = null;
            }
        }
    }


    // Carousel items for featured destinations
    public ObservableCollection<FeaturedItem> FeaturedDestinations { get; } = new();

    // Banner image (per your uploaded file — replace with real image file if necessary)
    // Developer note: included file path from your uploads as requested
    public string BannerImageUrl { get; set; } = "banner.png";

    public Command AddTripCommand { get; }

    public HomeViewModel()
    {
        AddTripCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(Views.AddTripPage));
        });

        // sample featured items — you should replace ImageUrl with real images in Resources/Images
        FeaturedDestinations.Add(new FeaturedItem { Title = "Paris", Subtitle = "Romantic city highlights", ImageUrl = "paris.jpg" });
        FeaturedDestinations.Add(new FeaturedItem { Title = "Kyoto", Subtitle = "Temples & culture", ImageUrl = "kyoto.jpg" });
        FeaturedDestinations.Add(new FeaturedItem { Title = "New York", Subtitle = "City that never sleeps", ImageUrl = "nyc.jpg" });
    }

    public async Task LoadHomeData()
    {
        IsBusy = true;

        var trips = await App.Database.GetTrips();
        var expenses = await App.Database.GetAllExpenses();

        TotalTrips = trips.Count;
        TotalExpenses = expenses.Sum(e => e.Amount);
        TotalBudget = trips.Sum(t => t.Budget);

        RecentTrips.Clear();
        foreach (var t in trips.OrderByDescending(t => t.Id).Take(4))
            RecentTrips.Add(t);

        IsBusy = false;
    }
}

// small helper model for featured items
public class FeaturedItem
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string ImageUrl { get; set; }
}
