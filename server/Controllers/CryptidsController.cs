namespace cryptipedia.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptidsController : ControllerBase
{

  private readonly CryptidsService _cryptidsService;
  private readonly CryptidEncountersService _cryptidEncountersService;
  private readonly Auth0Provider _auth0Provider;

  public CryptidsController(CryptidsService cryptidsService, Auth0Provider auth0Provider, CryptidEncountersService cryptidEncountersService)
  {
    _cryptidsService = cryptidsService;
    _auth0Provider = auth0Provider;
    _cryptidEncountersService = cryptidEncountersService;
  }

  [HttpPost, Authorize]
  public async Task<ActionResult<Cryptid>> CreateCryptid([FromBody] Cryptid cryptidData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cryptidData.DiscovererId = userInfo.Id;
      Cryptid cryptid = _cryptidsService.CreateCryptid(cryptidData);
      return Ok(cryptid);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Cryptid>> GetCryptids([FromQuery] string name) // [FromQuery] Cryptid query
  {
    try
    {
      List<Cryptid> cryptids;
      if (name == null) // if there's no query
      {
        cryptids = _cryptidsService.GetCryptids();
      }
      else
      {
        cryptids = _cryptidsService.GetCryptids(name);
      }
      return Ok(cryptids);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cryptidId}")]
  public ActionResult<Cryptid> GetCryptidById(int cryptidId)
  {
    try
    {
      Cryptid cryptid = _cryptidsService.GetCryptidById(cryptidId);
      return Ok(cryptid);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cryptidId}/cryptidEncounters")]
  public ActionResult<List<CryptidEncounterProfile>> GetCryptidEncounterProfilesByCryptidId(int cryptidId)
  {
    try
    {
      List<CryptidEncounterProfile> profiles = _cryptidEncountersService.GetCryptidEncounterProfilesByCryptidId(cryptidId);
      return Ok(profiles);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}