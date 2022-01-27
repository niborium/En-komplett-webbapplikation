using En_komplett_webbapplikation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace En_komplett_webbapplikation.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Rover> Rovers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rover>().HasData(new Rover { Id = 1, Name = "Spirit", NasaURL= "https://api.nasa.gov/mars-photos/api/v1/rovers/spirit/", Description = "Status: Uppdraget slutfört<br>Uppdragets varaktighet: 2269 dagar<br>Sista kontakt: 22 mars 2010<br>Landning: 4 januari 2004.", History = "Spirit, också känd som MER-A (Mars Exploration Rover – A) eller MER-2, var NASAs första sond i Marsutforskningsprogrammet Mars Exploration Rover Mission. Den sköts upp med en Delta II-raket från Cape Canaveral Air Force Station, den 10 juni 2003 och landade på Mars yta, den 3 januari 2004. Den är syskonfarkost till MER-B, kallad Opportunity. Uppdraget var tänkt att pågå i 90 dagar, men tack vare att solcellerna då och då blåstes rena av starka vindar på Mars, överlevde Spirit i 2 269 dagar.", Weight=180, NumberOfWheels=6 });
            modelBuilder.Entity<Rover>().HasData(new Rover { Id = 2, Name = "Opportunity", NasaURL = "https://api.nasa.gov/mars-photos/api/v1/rovers/opportunity/", Description = "Status: Uppdraget slutfört<br>Uppdragets varaktighet: 15 år och 19 dagar<br>Sista kontakt: 10 juni 2018<br>Landning: 25 januari 2004", History = "Opportunity, också känd som MER-B (Mars Exploration Rover – B) eller MER-1, med smeknamnet Oppy, var NASAs andra rymdsond i Mars-utforskningsprogrammet Mars Exploration Rover Mission. MER-B sköts iväg 8 juli 2003 och landade i området Meridiani planum på planeten Mars den 25 januari 2004. Den är tvillingfarkost till MER-A, Spirit. NASA förklarade den 13 februari 2019 uppdraget för avslutat då man inte sedan juni 2018 haft kontakt med farkosten. Detta efter att en större sandstorm dragit fram över området där den befann sig.", Weight = 180, NumberOfWheels=6 });
            modelBuilder.Entity<Rover>().HasData(new Rover { Id = 3, Name = "Curiosity", NasaURL = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/", Description = "Status: Uppdrag pågår<br>Landning: 6 augusti 2012", History = "Curiosity (Mars Science Laboratory, förkortas MSL) är en obemannad motoriserad landfarkost (strövare) som sköts upp på uppdrag av NASA den 26 november 2011. Enligt plan landade strövaren på Mars vid kratern Gale den 5 augusti 2012 kl. 05:31 UTC. Strövaren är tre gånger så tung och dubbelt så bred som de tidigare Mars Exploration Rovers (MER) Spirit och Opportunity som landade på Mars 2004.", Weight = 899, NumberOfWheels=6 });
        }
    }
}
