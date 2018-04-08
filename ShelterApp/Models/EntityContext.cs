using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Models
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet <UserEntity> Users { get; set; }
        public DbSet <AnimalEntity> Animals { get; set; }
        public DbSet <Study> Studies { get; set; }
        public DbSet <Apply> Applications { get; set; }
        public DbSet <Rating> Ratings { get; set; }
        public DbSet <AnimalImages> Imgs { get; set; }
    }
}
