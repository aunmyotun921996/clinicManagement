using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Booking.Http.config;
using Booking.Http.Request;
using Booking.Http.Response;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Booking.Http.Impl
{
    public class PatientServiceApi : IPatientServiceApi
    {
        private readonly IHttpClientFactory _http;
        private readonly ILogger<PatientServiceApi> _logger;
        private readonly ApiConfig _bookingDataConfig;

        public PatientServiceApi(IHttpClientFactory http, ILogger<PatientServiceApi> logger, IOptions<ApiConfig> bookingDataConfig)
        {
            _http = http;
            _logger = logger;
            _bookingDataConfig = bookingDataConfig.Value;
        }
        public async Task<ApiResponse<List<Patient>>> GetPatientByIds(List<int> ids)
        {
            using var httpClient = _http.CreateClient();

            var model = new PatientIdsModel(ids);
            var todoItemJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, MediaTypeNames.Application.Json);

            var jsonSerializerOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            using var httpResponseMessage = await httpClient.PostAsync("https://localhost:7235/patients/all/ids", todoItemJson);
            httpResponseMessage.EnsureSuccessStatusCode();
            var responseStr = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ApiResponse<List<Patient>>>(responseStr, jsonSerializerOption);
            return response;
        }

        private string BuildPatientServiceEndPoint()
        {

            return string.Empty;
        }
    }
}
