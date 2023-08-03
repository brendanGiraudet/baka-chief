using bakaChiefApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.UnitTests
{
    [Collection("DatabaseCollection")]
    public class DatabaseContextFixture : IDisposable
    {
        public DatabaseContext DbContext { get; private set; }

        public DatabaseContextFixture()
        {
            // Initialisez une nouvelle instance de DbContext pour chaque collection de tests
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            DbContext = new DatabaseContext(options);
        }

        public void Dispose()
        {
            // Supprimez la base de données en mémoire après chaque collection de tests
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }
}
