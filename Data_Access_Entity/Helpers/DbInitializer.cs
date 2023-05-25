using Data_Access_Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Entity.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[]
            {
                new Account()
                {
                    ID= 1,
                    ClientID= 1,
                    AccountType = "Admin",
                },
            });
        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
                new Client()
                {
                    ID= 1,
                    AccountID= 1,
                    FullName = "Victor Lyalchuk", 
                    Email = "Victor@ukr.net",
                    Login = "Admin",
                    Password = "123"
                },
            });

        }
        public static void SeedDevelopers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasData(new Developer[]
            {
                new Developer()
                {
                    ID= 1,
                    Name = "Rockstar Games",
                    Country = "USA",
                    NumberOfStaff = 2000
                },
                new Developer()
                {
                    ID= 2,
                    Name = "Avalanche Software",
                    Country = "USA",
                    NumberOfStaff = 1500
                },
                new Developer()
                {
                    ID= 3,
                    Name = "President Studio",
                    Country = "USA",
                    NumberOfStaff = 20
                },
                new Developer()
                {
                    ID= 4,
                    Name = "Infinity Ward",
                    Country = "USA",
                    NumberOfStaff = 20
                },
                new Developer()
                {
                    ID= 5,
                    Name = "CD PROJEKT RED",
                    Country = "Poland",
                    NumberOfStaff = 520
                },
                new Developer()
                {
                    ID= 6,
                    Name = "Respawn",
                    Country = "USA",
                    NumberOfStaff = 250
                },
                new Developer()
                {
                    ID= 7,
                    Name = "Larian Studios",
                    Country = "USA",
                    NumberOfStaff = 80
                },
                new Developer()
                {
                    ID= 8,
                    Name = "Naughty Dog LLC",
                    Country = "USA",
                    NumberOfStaff = 280
                },
                new Developer()
                {
                    ID= 9,
                    Name = "Criterion Games",
                    Country = "USA",
                    NumberOfStaff = 140
                },
                new Developer()
                {
                    ID= 10,
                    Name = "Visual Concepts",
                    Country = "USA",
                    NumberOfStaff = 180
                },
                new Developer()
                {
                    ID= 11,
                    Name = "EA Canada & EA Romania",
                    Country = "USA",
                    NumberOfStaff = 120
                },
                new Developer()
                {
                    ID= 12,
                    Name = "Endnight Games Ltd",
                    Country = "USA",
                    NumberOfStaff = 90
                },
            });

        }
        public static void SeedGames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                new Game()
                {
                    ID= 1,
                    Name = "Grand Theft Auto V",
                    CostPrice = 50,
                    Price = 120,
                    Raiting = 8,
                    ReleaseDate = new DateTime(2013,09,17),
                    CountOfSell = 10,
                    DeveloperID= 1,
                    PublisherID = 1,
                    GenreID = 1,
                    TagID= 2,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 2,
                    Name = "Hogwarts Legacy",
                    CostPrice = 70,
                    Price = 350,
                    Raiting = 7,
                    ReleaseDate = new DateTime(2023,02,10),
                    CountOfSell = 0,
                    DeveloperID= 2,
                    PublisherID = 2,
                    GenreID = 2,
                    TagID= 4,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 3,
                    Name = "I Am Your President",
                    CostPrice = 45,
                    Price = 220,
                    Raiting = 3,
                    ReleaseDate = new DateTime(2023,02,27),
                    CountOfSell = 0,
                    DeveloperID= 3,
                    PublisherID = 3,
                    GenreID = 3,
                    TagID= 5,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 4,
                    Name = "Call of Duty®: Modern Warfare® II",
                    CostPrice = 85,
                    Price = 450,
                    Raiting = 6,
                    ReleaseDate = new DateTime(2022,10,28),
                    CountOfSell = 2,
                    DeveloperID= 4,
                    PublisherID = 4,
                    GenreID = 1,
                    TagID= 6,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 5,
                    Name = "The Witcher® 3: Wild Hunt",
                    CostPrice = 75,
                    Price = 550,
                    Raiting = 9,
                    ReleaseDate = new DateTime(2015,05,18),
                    CountOfSell = 0,
                    DeveloperID= 5,
                    PublisherID = 5,
                    GenreID = 2,
                    TagID= 7,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 6,
                    Name = "STAR WARS Jedi: Survivor™",
                    CostPrice = 70,
                    Price = 550,
                    Raiting = 6,
                    ReleaseDate = new DateTime(2023,04,28),
                    CountOfSell = 0,
                    DeveloperID= 6,
                    PublisherID = 6,
                    GenreID = 1,
                    TagID= 8,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 7,
                    Name = "Red Dead Redemption 2",
                    CostPrice = 60,
                    Price = 450,
                    Raiting = 8,
                    ReleaseDate = new DateTime(2019,12,05),
                    CountOfSell = 150,
                    DeveloperID= 1,
                    PublisherID = 1,
                    GenreID = 2,
                    TagID= 7,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 8,
                    Name = "Divinity: Original Sin 2 - Definitive Edition",
                    CostPrice = 40,
                    Price = 240,
                    Raiting = 6,
                    ReleaseDate = new DateTime(2017,09,14),
                    CountOfSell = 0,
                    DeveloperID= 7,
                    PublisherID = 7,
                    GenreID = 2,
                    TagID= 7,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 9,
                    Name = "UNCHARTED™: Legacy of Thieves Collection",
                    CostPrice = 50,
                    Price = 380,
                    Raiting = 7,
                    ReleaseDate = new DateTime(2022,10,19),
                    CountOfSell = 0,
                    DeveloperID= 8,
                    PublisherID = 8,
                    GenreID = 4,
                    TagID= 4,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 10,
                    Name = "Need for Speed™ Unbound",
                    CostPrice = 35,
                    Price = 280,
                    Raiting = 5,
                    ReleaseDate = new DateTime(2022,12,02),
                    CountOfSell = 3,
                    DeveloperID= 9,
                    PublisherID = 6,
                    GenreID = 5,
                    TagID= 9,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 11,
                    Name = "NBA 2K23",
                    CostPrice = 45,
                    Price = 330,
                    Raiting = 6,
                    ReleaseDate = new DateTime(2022,09,08),
                    CountOfSell = 0,
                    DeveloperID= 10,
                    PublisherID = 9,
                    GenreID = 6,
                    TagID= 9,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 12,
                    Name = "EA SPORTS™ FIFA 23",
                    CostPrice = 85,
                    Price = 830,
                    Raiting = 7,
                    ReleaseDate = new DateTime(2022,09,30),
                    CountOfSell = 0,
                    DeveloperID= 11,
                    PublisherID = 6,
                    GenreID = 6,
                    TagID= 9,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 13,
                    Name = "Sons Of The Forest",
                    CostPrice = 25,
                    Price = 130,
                    Raiting = 6,
                    ReleaseDate = new DateTime(2023,02,23),
                    CountOfSell = 0,
                    DeveloperID= 12,
                    PublisherID = 10,
                    GenreID = 1,
                    TagID= 7,
                    OriginalGame = "",
                },
                new Game()
                {
                    ID= 14,
                    Name = "Cyberpunk 2077\r\n",
                    CostPrice = 55,
                    Price = 830,
                    Raiting = 7,
                    ReleaseDate = new DateTime(2020,10,12),
                    CountOfSell = 0,
                    DeveloperID= 5,
                    PublisherID = 5,
                    GenreID = 2,
                    TagID= 9,
                    OriginalGame = "",
                },
            });

        }
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre()
                {
                    ID= 1,
                    Name = "Action"
                },
                new Genre()
                {
                    ID= 2,
                    Name = "RPG"
                },
                new Genre()
                {
                    ID= 3,
                    Name = "Strategy"
                },
                new Genre()
                {
                    ID= 4,
                    Name = "Adventure"
                },
                new Genre()
                {
                    ID= 5,
                    Name = "Racing"
                },
                new Genre()
                {
                    ID= 6,
                    Name = "Sport"
                },
            });

        }
        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher()
                {
                    ID= 1,
                    Name = "Rockstar Games",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 2,
                    Name = "Warner Bros. Games",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 3,
                    Name = "President Studio",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 4,
                    Name = "Activision",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 5,
                    Name = "CD PROJEKT RED",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 6,
                    Name = "Electronic Arts",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 7,
                    Name = "Larian Studios",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 8,
                    Name = "PlayStation PC LLC",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 9,
                    Name = "2K",
                    Country = "USA"
                },
                new Publisher()
                {
                    ID= 10,
                    Name = "Newnight",
                    Country = "USA"
                },
            });


        }
        public static void SeedSupportedLanguages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupportedLanguage>().HasData(new SupportedLanguage[]
            {
                new SupportedLanguage()
                {
                    ID= 1,
                    Language = "English"
                },
                new SupportedLanguage()
                {
                    ID= 2,
                    Language = "French"
                },
                new SupportedLanguage()
                {
                    ID= 3,
                    Language = "German"
                },
            });

        }
        public static void SeedTags(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(new Tag[]
            {
                new Tag()
                {
                    ID= 1,
                    Name = "Сriminal game"
                },
                new Tag()
                {
                    ID= 2,
                    Name = "Include cursing"
                },
                new Tag()
                {
                    ID= 3,
                    Name = "New Year Game"
                },
                new Tag()
                {
                    ID= 4,
                    Name = "Family Game"
                },
                new Tag()
                {
                    ID= 5,
                    Name = "Indie Game"
                },
                new Tag()
                {
                    ID= 6,
                    Name = "Military Game"
                },
                new Tag()
                {
                    ID= 7,
                    Name = "Historical Game"
                },
                new Tag()
                {
                    ID= 8,
                    Name = "Cosmos Game"
                },
                new Tag()
                {
                    ID= 9,
                    Name = "Ection Game"
                },
            });

        }
    }
}
