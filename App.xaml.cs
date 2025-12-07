using TripBudgetPlanner.Database;

namespace TripBudgetPlanner;

public partial class App : Application
{
    // Singleton instance of your SQLite database
    private static DatabaseService _database;
    public static DatabaseService Database
    {
        get
        {
            if (_database == null)
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "TripPlanner.db3"
                );

                _database = new DatabaseService(dbPath);
            }

            return _database;
        }
    }

    public App()
    {
        InitializeComponent();

        // Start app with Shell navigation
        MainPage = new AppShell();
    }
}
