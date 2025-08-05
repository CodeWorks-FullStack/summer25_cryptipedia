namespace cryptipedia.Models;

// backing class for table
public class CryptidEncounter : RepoItem<int>
{
  public int CryptidId { get; set; }
  public string AccountId { get; set; }
}

// DTO (data transfer object)
// https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
public class CryptidEncounterProfile : Profile
{
  public int CryptidEncounterId { get; set; }
}