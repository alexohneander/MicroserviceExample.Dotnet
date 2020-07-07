using MicroServiceExample.UserService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceExample.UserService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=microserviceexample.sqlserver; initial catalog=MicroServiceExample; persist security info=True; user id=sa; password=Micr0ServiceEx@mpl3;");
        }
    }
}
