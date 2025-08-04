


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

  internal Cryptid GetCryptidById(int cryptidId)
  {
    Cryptid cryptid = _repository.GetById(cryptidId);
    if (cryptid == null) throw new Exception($"Invalid cryptid id: {cryptidId}");
    return cryptid;
  }

  internal List<Cryptid> GetCryptids()
  {
    List<Cryptid> cryptids = _repository.GetAll();
    return cryptids;
  }
  // NOTE overloads
  // overloads allows us to reuse the same name for a method with different parameter types/number of parameters
  internal List<Cryptid> GetCryptids(string name)
  {
    List<Cryptid> cryptids = _repository.GetAll(name);
    return cryptids;
  }
  internal List<Cryptid> GetCryptids(string name, string origin)
  {
    throw new NotImplementedException();
  }
  internal List<Cryptid> GetCryptids(int size)
  {
    throw new NotImplementedException();
  }
}