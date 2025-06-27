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

        [JsonPropertyName("valorAcumuladoProximoConcurso")]
        public double NextDrawPrize { get; set; }
    }

    public class MegaSenaService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl = "https://loteriascaixa-api.herokuapp.com/api/megasena/";

        public MegaSenaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MegaSenaResult>> GetAllResultsAsync()
        {
            var results = await _http.GetFromJsonAsync<List<MegaSenaResult>>(_baseUrl);
            return results ?? [];
        }        

        public async Task<MegaSenaResult?> GetLatestResultAsync()
        {
            return await _http.GetFromJsonAsync<MegaSenaResult>($"{_baseUrl}latest");
        }

        public async Task<MegaSenaResult?> GetResultByDrawAsync(int drawNumber)
        {
            return await _http.GetFromJsonAsync<MegaSenaResult>(
                $"{_baseUrl}{drawNumber}");
        }

        public async Task<List<MegaSenaResult>> GetLastResultsAsync(int count)
        {
            var allResults = await GetAllResultsAsync();

            if (allResults == null || allResults.Count == 0) return [];

            var latest = allResults.OrderByDescending(r => r.DrawNumber).First();
            var results = new List<MegaSenaResult> { latest };

            for (int i = 1; i < count; i++)
            {
                var draw = await GetResultByDrawAsync(latest.DrawNumber - i);
                if (draw != null)
                {
                    results.Add(draw);
                }
            }

            return results.OrderByDescending(r => r.DrawNumber).ToList();
        }
    }
}
