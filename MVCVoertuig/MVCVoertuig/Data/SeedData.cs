namespace MVCVoertuig.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VoertuigDbContext>();
                context.Database.EnsureCreated();
                if (!context.Voertuigen.Any())
                {
                    context.Voertuigen.AddRange(
                        new Models.Voertuig
                        {
                            Merk = "Toyota",
                            MerkType = "Corolla",
                            Bouwjaar = 2015,
                            Km = 50000,
                            VerkoopPrijs = 15000,
                            AanweizigInShowroom = true
                        },
                        new Models.Voertuig
                        {
                            Merk = "Honda",
                            MerkType = "Civic",
                            Bouwjaar = 2018,
                            Km = 30000,
                            VerkoopPrijs = 18000,
                            AanweizigInShowroom = false
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
