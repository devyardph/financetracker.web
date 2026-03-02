namespace DYS.FinanceTracker.Shared.Dtos
{
    public class DownloadDto
    {
        public Guid? Id { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }

    }
}
