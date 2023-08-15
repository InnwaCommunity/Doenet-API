using Microsoft.AspNetCore.Mvc;
namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestApiController : ControllerBase
  {
    public TestApiController()
    {

    }
    //get: api/testApi
    [HttpGet("GetInfo", Name = "GetInfo")]
    public string GetInfo()
    {
      return "Todo API Running .Version :1.0. DateTime: " + DateTime.Now;
    }
  }
}