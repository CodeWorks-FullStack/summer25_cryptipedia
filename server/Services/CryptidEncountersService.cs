



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

  internal void DeleteCryptidEncounter(int cryptidEncounterId, Account userInfo)
  {
    CryptidEncounter cryptidEncounter = GetCryptidEncounterById(cryptidEncounterId);
    if (cryptidEncounter.AccountId != userInfo.Id) throw new Exception($"YOU CANNOT DELETE ANOTHER USER'S DATA, {userInfo.Name.ToUpper()}!");
    _repository.Delete(cryptidEncounterId);
  }

  private CryptidEncounter GetCryptidEncounterById(int cryptidEncounterId)
  {
    CryptidEncounter cryptidEncounter = _repository.GetById(cryptidEncounterId);
    if (cryptidEncounter == null) throw new Exception($"Invalid id: {cryptidEncounterId}");
    return cryptidEncounter;
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