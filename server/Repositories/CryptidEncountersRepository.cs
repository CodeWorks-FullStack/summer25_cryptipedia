
namespace cryptipedia.Repositories;

public class CryptidEncountersRepository
{
  private readonly IDbConnection _db;

  public CryptidEncountersRepository(IDbConnection db)
  {
    _db = db;
  }
}