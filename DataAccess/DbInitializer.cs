using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DbInitializer
    {
        public static async Task SeedData(AppDbContext dbContext)
        {
            if (dbContext.Commitments.Any() || dbContext.Investors.Any()) 
            {
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Investors");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Commitments");

                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM sqlite_sequence WHERE name='Investors'");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM sqlite_sequence WHERE name='Commitments'");

                await dbContext.SaveChangesAsync();
            }

            var commitments = new List<Commitment>
            {
                new() { Id = 1, InvestorId = 1, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 2, InvestorId = 2, AssetClass = "Infrastructure", Amount = 31000000, Currency = "GBP" },
                new() { Id = 3, InvestorId = 3, AssetClass = "Hedge Funds", Amount = 58000000, Currency = "GBP" },
                new() { Id = 4, InvestorId = 4, AssetClass = "Private Equity", Amount = 72000000, Currency = "GBP" },
                new() { Id = 5, InvestorId = 4, AssetClass = "Natural Resources", Amount = 1000000, Currency = "GBP" },
                new() { Id = 6, InvestorId = 2, AssetClass = "Real Estate", Amount = 17000000, Currency = "GBP" },
                new() { Id = 7, InvestorId = 2, AssetClass = "Real Estate", Amount = 83000000, Currency = "GBP" },
                new() { Id = 8, InvestorId = 4, AssetClass = "Hedge Funds", Amount = 28000000, Currency = "GBP" },
                new() { Id = 9, InvestorId = 2, AssetClass = "Hedge Funds", Amount = 85000000, Currency = "GBP" },
                new() { Id = 10, InvestorId = 1, AssetClass = "Hedge Funds", Amount = 31000000, Currency = "GBP" },
                new() { Id = 11, InvestorId = 1, AssetClass = "Private Equity", Amount = 45000000, Currency = "GBP" },
                new() { Id = 12, InvestorId = 4, AssetClass = "Real Estate", Amount = 48000000, Currency = "GBP" },
                new() { Id = 13, InvestorId = 3, AssetClass = "Private Equity", Amount = 45000000, Currency = "GBP" },
                new() { Id = 14, InvestorId = 2, AssetClass = "Real Estate", Amount = 12000000, Currency = "GBP" },
                new() { Id = 15, InvestorId = 2, AssetClass = "Natural Resources", Amount = 30000000, Currency = "GBP" },
                new() { Id = 16, InvestorId = 4, AssetClass = "Real Estate", Amount = 94000000, Currency = "GBP" },
                new() { Id = 17, InvestorId = 2, AssetClass = "Real Estate", Amount = 17000000, Currency = "GBP" },
                new() { Id = 18, InvestorId = 4, AssetClass = "Private Debt", Amount = 86000000, Currency = "GBP" },
                new() { Id = 19, InvestorId = 1, AssetClass = "Hedge Funds", Amount = 32000000, Currency = "GBP" },
                new() { Id = 20, InvestorId = 4, AssetClass = "Natural Resources", Amount = 38000000, Currency = "GBP" },
                new() { Id = 21, InvestorId = 4, AssetClass = "Real Estate", Amount = 6000000, Currency = "GBP" },
                new() { Id = 22, InvestorId = 3, AssetClass = "Hedge Funds", Amount = 61000000, Currency = "GBP" },
                new() { Id = 23, InvestorId = 2, AssetClass = "Hedge Funds", Amount = 63000000, Currency = "GBP" },
                new() { Id = 24, InvestorId = 4, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 25, InvestorId = 1, AssetClass = "Private Equity", Amount = 70000000, Currency = "GBP" },
                new() { Id = 26, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 32000000, Currency = "GBP" },
                new() { Id = 27, InvestorId = 5, AssetClass = "Natural Resources", Amount = 38000000, Currency = "GBP" },
                new() { Id = 28, InvestorId = 5, AssetClass = "Real Estate", Amount = 6000000, Currency = "GBP" },
                new() { Id = 29, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 61000000, Currency = "GBP" },
                new() { Id = 30, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 63000000, Currency = "GBP" },
                new() { Id = 31, InvestorId = 5, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 32, InvestorId = 5, AssetClass = "Private Equity", Amount = 70000000, Currency = "GBP" },

                new() { Id = 33, InvestorId = 5, AssetClass = "Natural Resources", Amount = 38000000, Currency = "GBP" },
                new() { Id = 34, InvestorId = 5, AssetClass = "Real Estate", Amount = 6000000, Currency = "GBP" },
                new() { Id = 35, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 61000000, Currency = "GBP" },
                new() { Id = 36, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 63000000, Currency = "GBP" },
                new() { Id = 37, InvestorId = 5, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 38, InvestorId = 5, AssetClass = "Private Equity", Amount = 70000000, Currency = "GBP" },

                new() { Id = 39, InvestorId = 5, AssetClass = "Natural Resources", Amount = 38000000, Currency = "GBP" },
                new() { Id = 40, InvestorId = 5, AssetClass = "Real Estate", Amount = 6000000, Currency = "GBP" },
                new() { Id = 41, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 61000000, Currency = "GBP" },
                new() { Id = 43, InvestorId = 5, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 44, InvestorId = 5, AssetClass = "Private Equity", Amount = 70000000, Currency = "GBP" },

                new() { Id = 45, InvestorId = 5, AssetClass = "Natural Resources", Amount = 38000000, Currency = "GBP" },
                new() { Id = 46, InvestorId = 5, AssetClass = "Real Estate", Amount = 6000000, Currency = "GBP" },
                new() { Id = 47, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 61000000, Currency = "GBP" },
                new() { Id = 48, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 63000000, Currency = "GBP" },
                new() { Id = 49, InvestorId = 5, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 50, InvestorId = 5, AssetClass = "Private Equity", Amount = 70000000, Currency = "GBP" },
                new() { Id = 51, InvestorId = 5, AssetClass = "Hedge Funds", Amount = 63000000, Currency = "GBP" },
                new() { Id = 52, InvestorId = 5, AssetClass = "Infrastructure", Amount = 15000000, Currency = "GBP" },
                new() { Id = 53, InvestorId = 5, AssetClass = "Private Equity", Amount = 70000000, Currency = "GBP" }
            };

            var investors = new List<Investor>
            {
                new() { Id = 1, Name = "Ioo Gryffindor fund", Type = "fund manager", Country = "Singapore", DateAdded = new DateTime(2000, 7, 6), LastUpdated = new DateTime(2024, 2, 21) },
                new() { Id = 2, Name = "Ibx Skywalker ltd", Type = "asset manager", Country = "United States", DateAdded = new DateTime(1997, 7, 21), LastUpdated = new DateTime(2024, 2, 21) },
                new() { Id = 3, Name = "Cza Weasley fund", Type = "wealth manager", Country = "United Kingdom", DateAdded = new DateTime(2002, 5, 29), LastUpdated = new DateTime(2024, 2, 21) },
                new() { Id = 4, Name = "Mjd Jedi fund", Type = "bank", Country = "China", DateAdded = new DateTime(2010, 6, 8), LastUpdated = new DateTime(2024, 2, 21) },
                new() { Id = 5, Name = "Cza Weasley fund", Type = "wealth manager", Country = "United Kingdom", DateAdded = new DateTime(2010, 6, 8), LastUpdated = new DateTime(2024, 2, 21) }
            };

            dbContext.Investors.AddRange(investors);
            dbContext.Commitments.AddRange(commitments);

            await dbContext.SaveChangesAsync();
        }
    }
}