using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace MegaSenaBlazor.Services
{
    public class MegaSenaResult
    {
        [JsonPropertyName("concurso")]
        public int DrawNumber { get; set; }

        [JsonPropertyName("nomeLoteria")]
        public string LotteryName { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("dezenas")]
        public List<int> Numbers { get; set; } = [];

        [JsonPropertyName("dataProximoConcurso")]
        public string NextDrawDate { get; set; } = string.Empty;

        [JsonPropertyName("acumulou")]
        public bool IsAccumulated { get; set; }
    }

    public class MegaSenaService
    {
        private readonly HttpClient _http;
        private readonly string _drawUrl = "https://loteriascaixa-api.herokuapp.com/api/megasena/";
        private readonly string _latestUrl = $"https://loteriascaixa-api.herokuapp.com/api/megasena/latest";

        public MegaSenaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<MegaSenaResult?> GetLatestResultAsync()
        {

            return await _http.GetFromJsonAsync<MegaSenaResult>(_latestUrl);
        }

        public async Task<MegaSenaResult?> GetResultByDrawAsync(int drawNumber)
        {
            return await _http.GetFromJsonAsync<MegaSenaResult>(
                $"{_drawUrl}{drawNumber}");
        }
    }
}
