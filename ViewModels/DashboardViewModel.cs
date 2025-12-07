using System.Collections.ObjectModel;
using TripBudgetPlanner.Models;

namespace TripBudgetPlanner.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    public int TotalTrips { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal TotalBudget { get; set; }

    public ObservableCollection<CategoryBar> CategoryBars { get; set; } = new();
    public ObservableCollection<TopTrip> TopTrips { get; set; } = new();

    public async Task LoadDashboard()
    {
        var trips = await App.Database.GetTrips();
        var expenses = await App.Database.GetAllExpenses();

        // BASIC COUNTS
        TotalTrips = trips.Count;
        TotalExpenses = expenses.Sum(e => e.Amount);
        TotalBudget = trips.Sum(t => t.Budget);

        OnPropertyChanged(nameof(TotalTrips));
        OnPropertyChanged(nameof(TotalExpenses));
        OnPropertyChanged(nameof(TotalBudget));

        if (expenses.Count == 0)
        {
            CategoryBars.Clear();
            return;
        }

        // ---- CATEGORY BREAKDOWN ----
        var grouped = expenses
            .GroupBy(e => e.Category)
            .ToDictionary(g => g.Key, g => g.Sum(e => (double)e.Amount));

        double totalSpent = grouped.Sum(g => g.Value);

        // ---- COLORS ----
        Color[] palette =
        {
            Color.FromArgb("#0078FF"),
            Color.FromArgb("#FF5733"),
            Color.FromArgb("#2A9D8F"),
            Color.FromArgb("#F4A261"),
            Color.FromArgb("#E63946"),
            Color.FromArgb("#6A4C93"),
            Color.FromArgb("#457B9D")
        };

        // ---- BUILD PROGRESS BARS ----
        CategoryBars.Clear();
        int colorIndex = 0;

        foreach (var g in grouped)
        {
            var color = palette[colorIndex % palette.Length];
            colorIndex++;

            CategoryBars.Add(new CategoryBar
            {
                Label = g.Key,
                AmountText = $"${g.Value:F2}",
                Progress = totalSpent > 0 ? g.Value / totalSpent : 0,
                Color = color
            });
        }

        // ---- TOP 3 TRIPS ----
        TopTrips.Clear();

        var ranked = trips
            .Select(t => new TopTrip
            {
                Name = t.Name,
                Budget = t.Budget,
                TotalSpent = expenses.Where(e => e.TripId == t.Id).Sum(e => e.Amount)
            })
            .OrderByDescending(t => t.TotalSpent)
            .Take(3);

        foreach (var t in ranked)
            TopTrips.Add(t);
    }
}

public class TopTrip
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public decimal TotalSpent { get; set; }
}

// NEW MODEL
public class CategoryBar
{
    public string Label { get; set; }
    public double Progress { get; set; }     // 0 → 1
    public string AmountText { get; set; }   // "₹200"
    public Color Color { get; set; }
}
