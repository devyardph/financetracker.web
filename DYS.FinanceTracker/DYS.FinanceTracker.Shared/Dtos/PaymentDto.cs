namespace DYS.FinanceTracker.Shared.Dtos
{
    public class PaymentDto
    {
        public Guid? Id { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public float? Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public Guid? SubscriberId { get; set; }
        public string SubscriptionTier { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
    }
}
