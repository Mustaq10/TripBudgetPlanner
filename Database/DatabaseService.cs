using SQLite;
using TripBudgetPlanner.Models;

namespace TripBudgetPlanner.Database;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);

        // Create tables automatically
        _db.CreateTableAsync<Trip>().Wait();
        _db.CreateTableAsync<Expense>().Wait();
    }

    // ------------------------
    // TRIPS CRUD
    // ------------------------
    public Task<List<Trip>> GetTrips()
    {
        return _db.Table<Trip>().ToListAsync();
    }

    public Task<Trip> GetTripById(int id)
    {
        return _db.Table<Trip>()
                  .Where(t => t.Id == id)
                  .FirstOrDefaultAsync();
    }

    public Task<int> AddTrip(Trip trip)
    {
        return _db.InsertAsync(trip);
    }

    public Task<int> UpdateTrip(Trip trip)
    {
        return _db.UpdateAsync(trip);
    }

    public Task<int> DeleteTrip(Trip trip)
    {
        return _db.DeleteAsync(trip);
    }

    // ------------------------
    // EXPENSES CRUD
    // ------------------------
    public Task<List<Expense>> GetExpensesByTrip(int tripId)
    {
        return _db.Table<Expense>()
                  .Where(e => e.TripId == tripId)
                  .ToListAsync();
    }

    public Task<List<Expense>> GetAllExpenses()
    {
        return _db.Table<Expense>().ToListAsync();
    }

    public Task<int> AddExpense(Expense expense)
    {
        return _db.InsertAsync(expense);
    }

    public Task<int> UpdateExpense(Expense expense)
    {
        return _db.UpdateAsync(expense);
    }

    public Task<int> DeleteExpense(Expense expense)
    {
        return _db.DeleteAsync(expense);
    
    }

}
