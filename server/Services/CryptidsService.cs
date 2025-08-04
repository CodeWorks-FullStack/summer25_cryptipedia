

namespace cryptipedia.Services;

public class CryptidsService
{
  private readonly CryptidsRepository _repository;

  public CryptidsService(CryptidsRepository repository)
  {
    _repository = repository;
  }

  internal Cryptid CreateCryptid(Cryptid cryptidData)
  {
    Cryptid cryptid = _repository.Create(cryptidData);
    return cryptid;
  }

  internal List<Cryptid> GetCryptids()
  {
    List<Cryptid> cryptids = _repository.GetAll();
    return cryptids;
  }
}