using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RS1Seminarski.Hubs;
using RS1Seminarski.Modul.Models;
using RS1Seminarski.Modul_Smjestaj.Models;
using RS1Seminarski.ModulAutentifikacija.Models;

using RS1Seminarski.Prevoz.Models;

namespace RS1Seminarski.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Racun> Racun { get; set; }
        public DbSet<AplikacijaPosao> AplikacijaPosao { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }

        public DbSet<Vodic> Vodici { get; set; }
        public DbSet<Admin> Administratori { get; set; }
        public DbSet<Autobus> Autobus { get; set; }
        public DbSet<Aviokompanija> Aviokompanija { get; set; }
        public DbSet<PrevoznoSredstvo> PrevoznoSredstvo { get; set; }

        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Smjestaj> Smjestaj { get; set; }
        

        public DbSet<Putovanje> Putovanje { get; set; }
        public DbSet<PutovanjeSmjestaj> PutovanjeSmjestaj { get; set; }

        public DbSet<PutovanjePrevoznoSredstvo> PutovanjePrevoznoSredstvo { get; set; }
        public DbSet<PutovanjeGradovi> PutovanjeGradovi { get; set; }
        public DbSet<PlanProgram> PlanProgram { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }

        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Grupe> GrupePutovanja { get; set; }
        public DbSet<Osoba> Osobe { get; set; }

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ovdje pise FluentAPI konfiguraciju

          
        }
    }
}
