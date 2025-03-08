    namespace API.DTOs
{
    public class InvestorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
        public string Country { get; set; } = string.Empty;
        public string TotalCommitment { get; set; } = string.Empty;
    }
}