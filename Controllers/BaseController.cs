using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Microsoft.Extensions.Logging.Abstractions;
using TodoApi.Models;
using NuGet.Common;


namespace TodoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BaseController : Controller
  {
    public TokenData _tokenData=new TokenData();
    private ActionExecutingContext? _actionExecutionContext;
    // private readonly ILogger<T> _loggerInstance = NullLoggerFactory.Instance.CreateLogger<T>();
    // protected ILogger<T> Logger => HttpContext.RequestServices.GetService<ILogger<T>>() ?? _loggerInstance;
    public override void OnActionExecuting(ActionExecutingContext context)
    {

      _actionExecutionContext = context;
    }

    // protected string GetTokenData(string claimname)
    // {
    //   try
    //   {
    //     if (_actionExecutionContext == null)
    //       return "";

    //     ClaimsIdentity objclaim = _actionExecutionContext.HttpContext.User.Identities.Last();
    //     if (objclaim != null)
    //     {
    //       if (objclaim.FindFirst(claimname) != null)
    //         return objclaim.FindFirst(claimname)!.Value;
    //       else
    //       {
    //         // Logger.LogWarning("Get Token Data Not Found {claimname}", claimname);

    //         return "";
    //       }

    //     }
    //     else
    //       return "";
    //   }
    //   catch (Exception ex)
    //   {
    //     Console.WriteLine("GetApproverSettingWeb" + DateTime.Now + ex.Message);
    //     // Logger.LogError("Get Token Data Exception", ex);
    //     return "";
    //   }

    // }
  }
}