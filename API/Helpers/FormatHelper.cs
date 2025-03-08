namespace API.Helpers
{
    public static class FormatHelper
    {
        public static string FormatAmount(long amount)
        {
            return amount >= 1_000_000_000 ? $"{amount / 1_000_000_000:0.##}B" : $"{amount / 1_000_000:0.##}M";
        }
    }
}