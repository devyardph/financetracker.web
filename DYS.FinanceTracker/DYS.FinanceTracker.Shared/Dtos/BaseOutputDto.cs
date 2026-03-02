namespace DYS.FinanceTracker.Shared.Dtos
{
    public class BaseOutputDto
    {
        public string Feature { get; set; }
        public string Type { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public bool Authorized { get; set; } = true;
        public bool Existing { get; set; }
        public List<ErrorDto> Errors { get; set; } = new List<ErrorDto>();

    }
}
