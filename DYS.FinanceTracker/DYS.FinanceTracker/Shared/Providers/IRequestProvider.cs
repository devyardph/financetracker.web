using DYS.FinanceTracker.Shared.Dtos;

namespace DYS.FinanceTracker.Shared.Providers
{
    public interface IRequestProvider
    {
        void SetToken(string token);
        string BaseURI { get; set; }
        Task<BaseResponseDto> GetAsync<T>(string path, Dictionary<string, string> headers = null);
        Task<BaseResponseDto> PostAsync<T>(string path, object payload, Dictionary<string, string> headers = null);
        Task<BaseResponseDto> PostAsync<T>(string path, Dictionary<string, string> headers = null);
        Task<BaseResponseDto> PutAsync<T>(string path, object payload, Dictionary<string, string> headers = null);
        Task<BaseResponseDto> SendAsync<T>(string path, object payload = null);
        Task<BaseResponseDto> UploadAsync<T>(string path, HttpContent payload);
        Task<BaseResponseDto> DeleteAsync<T>(string path);
    }
}
