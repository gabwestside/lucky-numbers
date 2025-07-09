using System.Text.Json.Serialization;

namespace MegaSenaBlazor.Models;

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
    public double NextAccumulatedDrawPrize { get; set; }

    [JsonPropertyName("valorEstimadoProximoConcurso")]
    public double NextDrawPrize { get; set; }
}

