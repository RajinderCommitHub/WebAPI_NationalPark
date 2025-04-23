using Microsoft.EntityFrameworkCore;
using WebAPI_NationalPark_1035.Models;

namespace WebAPI_NationalPark_1035.Data
{
    public class AppllicationDbContext : DbContext
    {
        public AppllicationDbContext(DbContextOptions<AppllicationDbContext> options) 
            : base(options) 
        {  

        }
        public DbSet<NationalPark> NationalParks { get; set; }  
        public DbSet<Trail> Trails { get; set; }
    }
}
