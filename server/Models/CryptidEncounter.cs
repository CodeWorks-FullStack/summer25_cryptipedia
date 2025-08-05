namespace cryptipedia.Models;

// backing class for table
public class CryptidEncounter : RepoItem<int>
{
  public int CryptidId { get; set; }
  public string AccountId { get; set; }
}