using System.Text.Json;
using MegaSenaBlazor.Models;
using Microsoft.JSInterop;

namespace MegaSenaBlazor.Services;

public class LocalStorageService
{
  private readonly IJSRuntime _jsRuntime;
  private const string Key = "savedGames";

  public LocalStorageService(IJSRuntime jsRuntime)
  {
    _jsRuntime = jsRuntime;
  }

  public async Task SaveGameAsync(SavedGame game)
  {
    var existing = await GetSavedGamesAsync();

    if (!existing.Any(g => g.Numbers.OrderBy(n => n).SequenceEqual(game.Numbers.OrderBy(n => n))))
    {
      existing.Add(game);

      var json = JsonSerializer.Serialize(existing);

      await _jsRuntime.InvokeVoidAsync("localStorage.setItem", Key, json);
    }
  }

  public async Task<List<SavedGame>> GetSavedGamesAsync()
  {
    var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", Key);

    return string.IsNullOrEmpty(json)
        ? []
        : JsonSerializer.Deserialize<List<SavedGame>>(json)!;
  }

  public async Task SaveAllGamesAsync(List<SavedGame> games)
  {
    var json = JsonSerializer.Serialize(games);
    
    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", Key, json);
  }
}

