using SQLite;

namespace TripBudgetPlanner.Models;

public class BaseModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}
