using API.DTOs;
using API.Helpers;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController(AppDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestorDto>>> GetInvestors()
        {
            return await dbContext.Investors
                .Select(i => new InvestorDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type,
                    Country = i.Country,
                    TotalCommitment = FormatHelper.FormatAmount(i.Commitments.Sum(c => (long)c.Amount))
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommitmentDetailsDto>> GetCommitmentDetail(string id)
        {
            var name = dbContext.Investors.FirstOrDefault(i => i.Id == Convert.ToInt32(id))?.Name ?? "";
            var commitments = dbContext.Commitments.Where(c => c.InvestorId == Convert.ToInt32(id));

            var commitmentDtos = 
                await commitments.Select(c => new CommitmentDto
                {
                    Id = c.Id,
                    AssetClass = c.AssetClass,
                    Currency = c.Currency,
                    Amount = FormatHelper.FormatAmount((long)c.Amount)
                })
                .ToListAsync();

            var assetClasses = await commitments
                .GroupBy(c => c.AssetClass)
                .Select(g => new AssetClassDto
                {
                    Name = g.Key,
                    TotalAmount = FormatHelper.FormatAmount(g.Sum(a => (long)a.Amount))
                }).ToListAsync();

            var result = new CommitmentDetailsDto
            {
                Name = name,
                AssetClasses = assetClasses,
                Commitments = commitmentDtos
            };

            return result;
        }
    }
}