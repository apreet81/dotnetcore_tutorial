using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Tutorial.Data
{
    class SampleDbContextFactory : IDbContextFactory<AppDbContext>
    {
        public AppDbContext Create()
        {
            return new AppDbContext(@"Server=.;Database=DotNetCoreTutorial;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
    public class AppDbContext : DbContext
    {
        public AppDbContext(string connString) : base(connString)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
