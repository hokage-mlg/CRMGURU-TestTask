using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Concrete
{
    /// <summary>
    /// Defines the data context used to interact with the database.
    /// </summary>
    public class TestTaskContext : DbContext
    {
        /// <summary>
        /// Represents a set of country entities stored in a database
        /// </summary>
        public DbSet<Country> Countries { get; set; }
        /// <summary>
        /// Represents a set of city entities stored in a database
        /// </summary>
        public DbSet<City> Cities { get; set; }
        /// <summary>
        /// Represents a set of region entities stored in a database
        /// </summary>
        public DbSet<Region> Regions { get; set; }
        /// <summary>
        /// The constructor defines a call to Database.EnsureCreated(),
        /// which automatically creates it when there is no database.
        /// If the database already exists, then nothing happens.
        /// </summary>
        /// <param name="options"> Base options (because one type of context) </param>
        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options) => Database.EnsureCreated();
    }
}
