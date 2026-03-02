using DYS.FinanceTracker.Shared.Dtos;
using DYS.FinanceTracker.Shared.Extensions;
using System.Net.Http.Headers;
using System.Text;

namespace DYS.FinanceTracker.Shared.Providers
{
    public class RequestProvider : IRequestProvider, IDisposable
    {
        public string BaseURI { get; set; }

        private readonly HttpClient _httpClient;
        private CancellationTokenSource _cancellationTokenSource;
        public readonly IConfiguration _configuration;
        private string _token = "";
        //private readonly ILocalStorageService _localStorage;
        public void SetToken(string token) => _token = token;

        /// <summary>
        /// Requestprovider
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="configuration"></param>
        public RequestProvider(
            HttpClient httpClient,
            IConfiguration configuration
            //ILocalStorageService localStorage
            )
        {
            //_localStorage = localStorage;
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        /// <summary>
        /// Get async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<BaseResponseDto> GetAsync<T>(string path, Dictionary<string, string> headers = null)
        {
            var api = $"{BaseURI}{path}";
            _cancellationTokenSource = new CancellationTokenSource();

            return InvokeAsync<T>(
               client => client.GetAsync(api, _cancellationTokenSource.Token),
               response => response.Content.ReadAsStringAsync(), headers);
        }

        /// <summary>
        /// Head Method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <param name="data"></param>
        /// <param name="bypassDialogs"></param>
        /// <returns></returns>
        public Task<BaseResponseDto> SendAsync<T>(string path, object payload = null)
        {
            var api = $"{BaseURI}{path}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, api);
            if (payload != null)
            {
                var content = new StringContent(JsonExtensions.Convert(payload),
                Encoding.UTF8,
                "application/json");
            }

            return InvokeAsync<T>(
               client => client.SendAsync(request),
               response => response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Post method using json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <param name="data"></param>
        /// <param name="bypassDialogs"></param>
        /// <returns></returns>
        public Task<BaseResponseDto> PostAsync<T>(string path, object payload, Dictionary<string, string> headers = null)
        {
            var api = $"{BaseURI}{path}";

            var content = new StringContent(JsonExtensions.Convert(payload),
                Encoding.UTF8,
                "application/json");

            return InvokeAsync<T>(
               client => client.PostAsync(api, content),
               response => response.Content.ReadAsStringAsync(), headers);
        }

        public Task<BaseResponseDto> PostAsync<T>(string path, Dictionary<string, string> headers = null)
        {
            var api = $"{BaseURI}{path}";

            return InvokeAsync<T>(
               client => client.PostAsync(api, null),
               response => response.Content.ReadAsStringAsync(), headers);
        }

        /// <summary>
		/// Put method using json
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path"></param>
		/// <param name="parameters"></param>
		/// <param name="data"></param>
		/// <param name="bypassDialogs"></param>
		/// <returns></returns>
		public Task<BaseResponseDto> PutAsync<T>(string path, object payload, Dictionary<string, string> headers = null)
        {
            var api = $"{BaseURI}{path}";

            var content = new StringContent(JsonExtensions.Convert(payload),
                Encoding.UTF8,
                "application/json");

            return InvokeAsync<T>(
               client => client.PutAsync(api, content),
               response => response.Content.ReadAsStringAsync(), headers);
        }

        /// <summary>
        /// Delete async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<BaseResponseDto> DeleteAsync<T>(string path)
        {
            var api = $"{BaseURI}{path}";

            return InvokeAsync<T>(
               client => client.DeleteAsync(api),
               response => response.Content.ReadAsStringAsync());
        }


        public Task<BaseResponseDto> UploadAsync<T>(string path, HttpContent payload)
        {
            var api = $"{BaseURI}{path}";

            return InvokeAsync<T>(
               client => client.PostAsync(api, payload),
               response => response.Content.ReadAsStringAsync());
        }


        /// <summary>
        ///  Invoke Http method 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operation"></param>
        /// <param name="actionOnResponse"></param>
        /// <param name="bypassDialogs"></param>
        /// <returns></returns>
        private async Task<BaseResponseDto> InvokeAsync<T>(
        Func<HttpClient, Task<HttpResponseMessage>> operation,
        Func<HttpResponseMessage, Task<string>> actionOnResponse,
        Dictionary<string, string> headers = null)
        {
            BaseResponseDto httpResponse = new BaseResponseDto();
            try
            {
                if (operation == null)
                {
                    throw new ArgumentNullException(nameof(operation));
                }

                _httpClient.DefaultRequestHeaders.Clear();

                //TODO FIX PASSING OF TOKEN
                //var token = await _localStorage.GetItemAsync<string>("authToken");

                //if (!string.IsNullOrEmpty(token))
                //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        if (item.Key.Contains("bearer"))
                            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(item.Key, item.Value);
                        else
                            _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                HttpResponseMessage response = await operation(_httpClient).ConfigureAwait(false);
                var httpContent = await actionOnResponse(response).ConfigureAwait(false);
                httpResponse = new BaseResponseDto(httpContent, response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return httpResponse;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
