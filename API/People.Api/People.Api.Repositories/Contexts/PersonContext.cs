using Microsoft.EntityFrameworkCore;
using People.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Api.Repositories.Contexts
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
