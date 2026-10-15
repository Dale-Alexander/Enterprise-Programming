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
         *Steps to create the database
         *Preparation: install all the required dependencies from NuGet particularly Microsoft.EntityFrameworkCore.Tools
         *1. Compile the entire solution and check that there are errors in the code
         *2. You have to set up the web application as the startup project
         *3. Open the package manager console window from Tools -> Nuget Package Manager -> Package Manager Console
         *4. Select as a default project in a drop-down in package manager console window: DataAccess
         *5. add-migration "InitialMigration" -context [press tab] select Library DbContext
         *6. Check the migration class
         *7. update-database -context [press tab] select LibraryDbContext
         *
         *Note: If you add a new model/add new properties/change anything which was created so far,
         *you need to repeat the steps above
         *
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
