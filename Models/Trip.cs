using SQLite;

namespace TripBudgetPlanner.Models;

public class Trip : BaseModel
{
    public string Name { get; set; }
    public decimal Budget { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Optional future: Cloud sync or user ID
    public bool IsSynced { get; set; } = false;
}
