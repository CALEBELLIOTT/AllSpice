using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StepsController : ControllerBase
  {
    private readonly StepsService _ss;

    public StepsController(StepsService ss)
    {
      _ss = ss;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Step>> CreateStepAsync([FromBody] Step stepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _ss.CreateStep(stepData, userInfo.Id);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Step> GetStepById(int id)
    {
      try
      {
        return _ss.GetStepById(id);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> deleteStepAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _ss.DeleteStep(id, userInfo.Id);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}