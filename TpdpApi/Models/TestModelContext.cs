using Microsoft.EntityFrameworkCore;


namespace TpdpApi.Models
{
    public class TestModelContext : DbContext
    {
        public TestModelContext(DbContextOptions<TestModelContext> options)
            : base(options)
        {
        }

        public DbSet<TestModel> TestItems { get; set; }
    }
}
