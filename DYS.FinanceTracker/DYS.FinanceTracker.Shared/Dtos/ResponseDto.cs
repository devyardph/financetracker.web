using Newtonsoft.Json;
using System.Net;

namespace DYS.FinanceTracker.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Result { get; set; }
        public string TargetUrl { get; set; }
        public bool Success { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public ErrorResponseDto Error { get; set; }
    }
}
