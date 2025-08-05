


namespace cryptipedia.Services;

public class CryptidEncountersService
{
  private readonly CryptidEncountersRepository _repository;

  public CryptidEncountersService(CryptidEncountersRepository repository)
  {
    _repository = repository;
  }

  internal CryptidEncounterProfile CreateCryptidEncounter(CryptidEncounter cryptidEncounterData)
  {
    CryptidEncounterProfile profile = _repository.Create(cryptidEncounterData);
    return profile;
  }

  internal List<CryptidEncounterProfile> GetCryptidEncounterProfilesByCryptidId(int cryptidId)
  {
    List<CryptidEncounterProfile> profiles = _repository.GetCryptidEncounterProfilesByCryptidId(cryptidId);
    return profiles;
  }

  internal List<CryptidEncounterCryptid> GetEncounteredCryptidsByAccountId(string accountId)
  {
    List<CryptidEncounterCryptid> cryptids = _repository.GetEncounteredCryptidsByAccountId(accountId);
    return cryptids;
  }
}