namespace API.DTOs
{
    public class CommitmentDetailsDto
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CommitmentDto> Commitments { get; set; } = [];
        public IEnumerable<AssetClassDto> AssetClasses { get; set; } = [];
    }
    public class CommitmentDto
    {
        public int Id { get; set; }
        public string AssetClass { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string Currency { get; set; } = "GBP";
    }

    public class AssetClassDto
    {
        public string Name { get; set; } = string.Empty;
        public string TotalAmount { get; set; } = string.Empty;
    }
}