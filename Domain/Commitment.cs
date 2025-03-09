namespace Domain
{
    public class Commitment
    {
        public int Id { get; set; }

        public int InvestorId { get; set; }

        public string AssetClass { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "GBP";
        
        public Investor Investor { get; set; }
    }
}