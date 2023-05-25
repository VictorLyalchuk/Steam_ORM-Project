using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Entity.Helpers;
using Data_Access_Entity.Entities;

namespace Data_Access_Entity
{
    public class SteamContext : DbContext
    {
        public SteamContext()
        {
           //Database.EnsureDeleted();
           //Database.EnsureCreated();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SupportedLanguage> SupportedLanguages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ClientGame> ClientGame { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
/*                                   optionsBuilder.UseSqlServer($@"Data Source=COREi5;
                                                                Initial Catalog = Steam;
                                                                Integrated Security=True;
                                                                Connect Timeout=30;
                                                                Encrypt=False;
                                                                TrustServerCertificate=False;
                                                                ApplicationIntent=ReadWrite;
                                                                MultiSubnetFailover=False");*/
            optionsBuilder.UseSqlServer($@"workstation id=DataSteam.mssql.somee.com;packet size=4096;user id=dannykaye7_SQLLogin_1;pwd=xgbe9gay2u;data source=DataSteam.mssql.somee.com;persist security info=False;initial catalog=DataSteam");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedAccounts();
            modelBuilder.SeedClients();
            modelBuilder.SeedDevelopers();
            modelBuilder.SeedGames();
            modelBuilder.SeedGenres();
            modelBuilder.SeedPublishers();
            modelBuilder.SeedSupportedLanguages();
            modelBuilder.SeedTags();

            modelBuilder.Entity<Game>().
                HasOne(g => g._Developer).
                WithMany(d => d._Games).
                HasForeignKey(d => d.DeveloperID);
            modelBuilder.Entity<Game>().
                HasOne(g => g._Publisher).
                WithMany(p => p._Games).
                HasForeignKey(d => d.PublisherID);
            modelBuilder.Entity<Game>().
                HasOne(g => g._Genre).
                WithMany(g => g._Games).
                HasForeignKey(d => d.GenreID);
            modelBuilder.Entity<Game>().
                HasOne(g => g._Tag).
                WithMany(t => t._Games).
                HasForeignKey(d => d.TagID);
            modelBuilder.Entity<Game>().
                HasMany(g => g._SupportedLanguages).
                WithMany(sl => sl._Games);
            modelBuilder.Entity<Client>().
                HasOne(c => c._Account).
                WithOne(a => a._Client).
                //HasForeignKey<Client>(c => c.AccountID);
                HasForeignKey<Account>(c => c.ClientID);
            modelBuilder.Entity<ClientGame>().HasKey(cg => new {cg.ClientID, cg.GameID});
            modelBuilder.Entity<ClientGame>().
                HasOne(c => c._Client).
                WithMany(c => c._ClientGame).
                HasForeignKey(c => c.ClientID);
            modelBuilder.Entity<ClientGame>().
                HasOne(c => c._Game).
                WithMany(c => c._ClientGame).
                HasForeignKey(c => c.GameID);

        }
    }
}
