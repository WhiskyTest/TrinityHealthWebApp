using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;
using TrinityHealth.Core;

namespace TrinityHealth.Data
{
    public class TrinityHealthDbContext : DbContext
    {
        public TrinityHealthDbContext(DbContextOptions<TrinityHealthDbContext> options)
            : base(options)
        {

        }
        public DbSet<Exercise> Exercises {get;set;}
    }
}
