namespace DYS.FinanceTracker.Shared.Dtos
{
    public class ThemeDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; } = "USD";
        public string Path { get; set; }
        public string PaymentLink { get; set; }

        public bool Selected { get; set; } = false;
    }
}
