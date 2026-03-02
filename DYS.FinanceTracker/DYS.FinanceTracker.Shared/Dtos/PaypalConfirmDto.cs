using System.Text.Json;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class PaypalConfirmDto
    {
        public string UserId { get; set; }
        public string SubscriptionCode { get; set; }
        public string SubscriptionTier { get; set; }
        public JsonElement Data { get; set; }
        public JsonElement Details { get; set; }
    }
}
