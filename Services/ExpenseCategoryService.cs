namespace TripBudgetPlanner.Services;

public static class ExpenseCategoryService
{
    public static List<string> GetCategories() =>
        new()
        {
            "Food",
            "Transport",
            "Lodging",
            "Activities",
            "Shopping",
            "Tickets",
            "Misc"
        };
}
