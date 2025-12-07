using System.Collections.ObjectModel;
using System.Windows.Input;
using TripBudgetPlanner.Models;
using TripBudgetPlanner.Views;

namespace TripBudgetPlanner.ViewModels
{
    public class TripListViewModel : BaseViewModel
    {
        public ObservableCollection<TripListCard> Trips { get; set; } = new();

        // Command that will be triggered on card tap
        public ICommand OpenTripCommand { get; }

        private readonly List<string> _imagePool = new()
        {
            "https://images.unsplash.com/photo-1507525428034-b723cf961d3e",
            "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee",
            "https://images.unsplash.com/photo-1505761671935-60b3a7427bad",
            "https://images.unsplash.com/photo-1501785888041-af3ef285b470",
            "https://images.unsplash.com/photo-1500048993953-d23a436266cf",
            "https://images.unsplash.com/photo-1473625247510-8ceb1760943f",
            "https://images.unsplash.com/photo-1491553895911-0055eca6402d",
            "https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef",
            "https://images.unsplash.com/photo-1500534623283-312aade485b7",
            "https://images.unsplash.com/photo-1441974231531-c6227db76b6e",
            "https://images.unsplash.com/photo-1470071459604-3b5ec3a7fe05",
            "https://images.unsplash.com/photo-1500534314209-a25ddb2bd429",
            "https://images.unsplash.com/photo-1519817650390-64a93db511aa",
            "https://images.unsplash.com/photo-1500534628430-76ac3798a5e1",
            "https://images.unsplash.com/photo-1516900557549-41557bcd7209",
            "https://images.unsplash.com/photo-1469474968028-56623f02e42e",
            "https://images.unsplash.com/photo-1493558103817-58b2924bce98",
            "https://images.unsplash.com/photo-1500534316031-c6e1f5b9d710",
            "https://images.unsplash.com/photo-1483683804023-6ccdb62f86ff",
            "https://images.unsplash.com/photo-1501785981353-cbb34b1a23ba"
        };

        private readonly Random _rand = new();

        private string GetRandomImage() =>
            _imagePool[_rand.Next(_imagePool.Count)];

        public TripListViewModel()
        {
            OpenTripCommand = new Command<TripListCard>(async (trip) => await OnTripSelected(trip));
        }

        public async Task LoadTrips()
        {
            Trips.Clear();

            var dbTrips = await App.Database.GetTrips();

            foreach (var t in dbTrips)
            {
                var expenses = await App.Database.GetExpensesByTrip(t.Id);
                double spent = expenses.Sum(x => (double)x.Amount);

                double progress = (t.Budget > 0) ? spent / (double)t.Budget : 0;
                if (progress > 1) progress = 1;

                Trips.Add(new TripListCard
                {
                    Id = t.Id,
                    Name = t.Name,
                    Budget = t.Budget,
                    TotalSpent = spent,
                    TotalSpentText = $"Spent: ${spent:F0}",
                    Progress = progress,
                    ProgressBarWidth = progress * 250, // width in px for bar
                    DateRange = $"{t.StartDate:MMM dd} - {t.EndDate:MMM dd}",
                    ImageUrl = GetRandomImage()
                });
            }
        }

        private async Task OnTripSelected(TripListCard trip)
        {
            if (trip == null)
                return;

            try
            {
                await Shell.Current.GoToAsync($"{nameof(TripDetailsPage)}?tripId={trip.Id}");
            }
            catch (Exception ex)
            {
                // Optional: show error if navigation fails
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }
    }

    public class TripListCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public double TotalSpent { get; set; }
        public string TotalSpentText { get; set; }
        public double Progress { get; set; }
        public double ProgressBarWidth { get; set; }
        public string DateRange { get; set; }
        public string ImageUrl { get; set; }
    }
}
