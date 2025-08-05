using System.ComponentModel.DataAnnotations;

namespace cryptipedia.Models;

public class Cryptid : RepoItem<int>
{
  public string Name { get; set; }
  [Range(0, 10)] public int ThreatLevel { get; set; }
  [Url] public string ImgUrl { get; set; }
  public string Origin { get; set; }
  [Range(0, 10)] public int Size { get; set; }
  [MaxLength(5000)] public string Description { get; set; }
  public string DiscovererId { get; set; }
  public Profile Discoverer { get; set; }
  public int EncounterCount { get; set; }
}
