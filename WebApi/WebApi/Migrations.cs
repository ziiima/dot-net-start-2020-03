using DbUp;
using DbUp.Postgresql;
using System.Reflection;

namespace WebApi.Migrations
{
    public class MigrationExtensions
    {
        private string connectionString;

        public MigrationExtensions(string connectionString) {
            this.connectionString = connectionString;
        }

        public void EnsureConnection()
        {
            EnsureDatabase.For.PostgresqlDatabase(this.connectionString);
        }

        public void RunMigrations()
        {
            try
            {
                var upgrader = DeployChanges.To
                    .PostgresqlDatabase(this.connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

                var result = upgrader.PerformUpgrade();

                if (result.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Migration Success!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Migration Failed: {result.Error}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Migration Error: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}