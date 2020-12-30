using Microsoft.EntityFrameworkCore;
using SehirRehber.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehber.WebApi.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> option):base(option)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
