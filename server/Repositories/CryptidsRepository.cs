using cryptipedia.Interfaces;

namespace cryptipedia.Repositories;

public class CryptidsRepository : IRepository<Cryptid>
{
  private readonly IDbConnection _db;

  public CryptidsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Cryptid Create(Cryptid data)
  {
    string sql = @"
    INSERT INTO 
    cryptids(name, description, threat_level, discoverer_id, size, img_url, origin)
    VALUES(@Name, @Description, @ThreatLevel, @DiscovererId, @Size, @ImgUrl, @Origin);
    
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON accounts.id = cryptids.discoverer_id
    WHERE cryptids.id = LAST_INSERT_ID();";

    Cryptid newCryptid = _db.Query(sql,
    (Cryptid cryptid, Profile account) =>
    {
      cryptid.Discoverer = account;
      return cryptid;
    },
    data).SingleOrDefault();

    return newCryptid;
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<Cryptid> GetAll()
  {
    throw new NotImplementedException();
  }

  public Cryptid GetById(int id)
  {
    throw new NotImplementedException();
  }

  public void Update(Cryptid data)
  {
    throw new NotImplementedException();
  }
}