




namespace cryptipedia.Repositories;

public class CryptidEncountersRepository
{
  private readonly IDbConnection _db;

  public CryptidEncountersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal CryptidEncounterProfile Create(CryptidEncounter cryptidEncounterData)
  {
    string sql = @"
    INSERT INTO
    cryptid_encounters(account_id, cryptid_id)
    VALUES(@AccountId, @CryptidId);
    
    SELECT
    cryptid_encounters.id AS cryptid_encounter_id,
    accounts.*
    FROM cryptid_encounters
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.id = LAST_INSERT_ID();";

    CryptidEncounterProfile profile = _db.Query<CryptidEncounterProfile>(sql, cryptidEncounterData).SingleOrDefault();

    return profile;
  }

  internal void Delete(int cryptidEncounterId)
  {
    string sql = "DELETE FROM cryptid_encounters WHERE id = @cryptidEncounterId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { cryptidEncounterId });

    if (rowsAffected != 1) throw new Exception($"UH OH {rowsAffected} ROWS ARE NOW GONE!!!");
  }

  internal CryptidEncounter GetById(int cryptidEncounterId)
  {
    string sql = "SELECT * FROM cryptid_encounters WHERE id = @cryptidEncounterId;";

    CryptidEncounter cryptidEncounter = _db.Query<CryptidEncounter>(sql, new { cryptidEncounterId }).SingleOrDefault();
    return cryptidEncounter;
  }

  internal List<CryptidEncounterProfile> GetCryptidEncounterProfilesByCryptidId(int cryptidId)
  {
    string sql = @"
    SELECT
    accounts.*,
    cryptid_encounters.id AS cryptid_encounter_id
    FROM cryptid_encounters
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.cryptid_id = @cryptidId;";

    List<CryptidEncounterProfile> profiles = _db.Query<CryptidEncounterProfile>(sql, new { cryptidId }).ToList();

    return profiles;
  }

  internal List<CryptidEncounterCryptid> GetEncounteredCryptidsByAccountId(string accountId)
  {

    // NOTE this works just fine
    // string sql = @"
    // SELECT
    // cryptid_encounters.*,
    // cryptids.*,
    // accounts.*
    // FROM cryptid_encounters
    // JOIN cryptids ON cryptid_encounters.cryptid_id = cryptids.id
    // JOIN accounts ON accounts.id = cryptids.discoverer_id
    // WHERE cryptid_encounters.account_id = @accountId;";

    // List<CryptidEncounterCryptid> cryptids = _db.Query(sql,
    //   (CryptidEncounter cryptidEncounter, CryptidEncounterCryptid cryptid, Profile account) =>
    //   {
    //     cryptid.CryptidEncounterId = cryptidEncounter.Id;
    //     cryptid.Discoverer = account;
    //     return cryptid;
    //   },
    //  new { accountId }).ToList();

    string sql = @"
    SELECT
    cryptids.*,
    cryptid_encounters.id AS cryptid_encounter_id,
    accounts.*
    FROM cryptid_encounters
    JOIN cryptids ON cryptid_encounters.cryptid_id = cryptids.id
    JOIN accounts ON accounts.id = cryptids.discoverer_id
    WHERE cryptid_encounters.account_id = @accountId;";

    List<CryptidEncounterCryptid> cryptids = _db.Query(sql,
      (CryptidEncounterCryptid cryptid, Profile account) =>
      {
        cryptid.Discoverer = account;
        return cryptid;
      },
     new { accountId }).ToList();

    return cryptids;
  }
}