using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keycloak.Lab.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class PolicyTestController : ControllerBase
  {
    readonly ILogger<PolicyTestController> _logger;

    public PolicyTestController(ILogger<PolicyTestController> logger)
    {
      _logger = logger;
    }

    [Authorize(Policy ="Reader")]
    [HttpGet]
    public IActionResult ReadersOnly()
    {
      return Ok($"{nameof(ReadersOnly)} worked!");
    }

    [Authorize(Policy = "AdminOrWriters")]
    [HttpPost]
    public IActionResult AdminOrWriters()
    {
      return Ok($"{nameof(AdminOrWriters)} worked!");
    }

    [Authorize(Policy ="Admin")]
    [HttpPut]
    public IActionResult AdminsOnly()
    {
      return Ok($"{nameof(AdminsOnly)} worked!");
    }

    [Authorize(Policy = "ReadAndWriters")]

    [HttpDelete]
    public IActionResult ReadAndWriters()
    {
      return Ok($"{nameof(ReadAndWriters)} worked!");
    }
  }
}
