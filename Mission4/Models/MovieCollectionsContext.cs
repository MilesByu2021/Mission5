using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    //inherit from the parent program to here by using Microsoft.EntityFrameworkCore
    public class MovieCollectionsContext : DbContext
    {
        public MovieCollectionsContext(DbContextOptions<MovieCollectionsContext> options) : base (options)
        {
            //leave blank here
        }

        public DbSet<AddNewMovie> AddNewMovies { get; set; }

        public DbSet<Category> Categories { get; set; }

        //Override and post the below object into the database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = " Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            mb.Entity<AddNewMovie>().HasData
                (
                    new AddNewMovie
                    {
                        MovieId = 1,
                        CategoryId = 1,
                        Title = "The Godfather",
                        Year = 1972,
                        Director = "Francis Ford Coppola",
                        Rating = "R",
                        Edited = false,
                        Lent = "Shaun",
                        Notes ="Michael is the real boss"

                    },
                    new AddNewMovie
                    {
                        MovieId = 2,
                        CategoryId = 1,
                        Title = "Spider-Man: No Way Home",
                        Year = 2022,
                        Director = "Jon Watts",
                        Rating = "PG-13",
                        Edited = false,
                        Lent = "Thor",
                        Notes = "Peter Parker is Spiderman"

                    },
                    new AddNewMovie
                    {
                        MovieId = 3,
                        CategoryId = 1,
                        Title = "Snake Eyes",
                        Year = 2021,
                        Director = "Robert Schwentke",
                        Rating = "PG-13",
                        Edited = true,
                        Lent = "Caden",
                        Notes = "Sanke Eyes can speak!"

                    }

                );
        }

    }
}
