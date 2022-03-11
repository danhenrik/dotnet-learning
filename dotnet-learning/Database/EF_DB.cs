using Microsoft.EntityFrameworkCore;
using dotnetlearning.Models;

namespace dotnetlearning.Database
{
    public class AppDbContext : DbContext
    {
        private string DB_Server;
        private string DB_User;
        private string DB_Password;
        private string DB_Database;
        public AppDbContext(DbContextOptions options) : base(options)
        {
            DB_Server = Environment.GetEnvironmentVariable("DB_SERVER");
            DB_User = Environment.GetEnvironmentVariable("DB_USER");
            DB_Password = Environment.GetEnvironmentVariable("DB_PWD");
            DB_Database = Environment.GetEnvironmentVariable("DB_DB");

            if (DB_Server == null || DB_User == null || DB_Password == null || DB_Database == null)
                throw new Exception("Credenciais do banco de dados imcompletas");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql($"server={DB_Server};uid={DB_User};pwd={DB_Password};database={DB_Database}",
                ServerVersion.Parse("5.7.33-mysql"));

        // Criação das tabelas baseado no models
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Local> Locals { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Participation> Participations { get; set; }
    }
}
