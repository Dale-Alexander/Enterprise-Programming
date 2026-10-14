using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibraryDbContext : IdentityDbContext<IdentityUser>
    {
        /* 
         *What is the role of this context class?
         *This is an abstraction of the database
         *In other words a database represented as a class
         */


        //package Microsoft.AspNetCore.Identity.FrameworkCore has these models -> User, Role etc
        //IdentityDbContext is another built in context class which has DbSets such as
        //Users, Roles, UserRoles, ..., using Models User, Role,etc

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        //We need the DbcontextOptions so in the Program.cs, you might need to pass some values from the
        //very beginning ex:conection string
        //stuff which regulate how string the password of a registered user should be
        //which database server you want to use
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        //other things which go inside the context class:
        //configuring the identity seed
        //generating column values eg: Guid datatypes to be automatically generated and stored in id columns
        // enabling lazy loading

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
