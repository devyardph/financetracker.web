namespace DYS.FinanceTracker.Shared.Dtos
{
    public class SearchDto
    {
        public string Id { get; set; } = string.Empty;
        public string Keyword { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 15;

    }
}
