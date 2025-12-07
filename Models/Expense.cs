using SQLite;

namespace TripBudgetPlanner.Models;

public class Expense : BaseModel
{
    public int TripId { get; set; }
    public string Description { get; set; }

    public decimal Amount { get; set; }
    public DateTime CreatedOn { get; set; }

    // Optional: category support for charts later
    public string Category { get; set; } = "General";
}
