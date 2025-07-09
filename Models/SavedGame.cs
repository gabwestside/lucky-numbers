namespace MegaSenaBlazor.Models;

public class SavedGame
{
  public List<int> Numbers { get; set; } = [];
  public DateTime CreatedAt { get; set; } = DateTime.Now;
}
