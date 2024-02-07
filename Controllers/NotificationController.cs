using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public NotificationController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("SentNotificationList", Name = "SentNotificationList")]
        public async Task<dynamic> SentNotificationList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            string userId = obj.UserId;
            int loginUserId=int.Parse(userId);
            
            try
            {
                dynamic res= await _repositoryWrapper.Notification.SentNotificationList(loginUserId);
                List<dynamic> newres=new List<dynamic> ();
                foreach (var item in res)
                {
                    if (item.NotiType == "MemberRequest")
                    {
                        var newnoti = new
                        {
                            NotiId = Encryption.EncryptID(item.NotiId.ToString(), loginUserId.ToString()),
                            Description = item.Description,
                            NotiType = item.NotiType,
                            DetailId = Encryption.EncryptID(item.DetailId.ToString(), loginUserId.ToString()),
                            SentDate = System.DateTime.Now
                        };
                        newres.Add(newnoti);
                        var updatenoti = new Notification
                        {
                            NotiId = item.NotiId,
                            Description = item.Description,
                            NotiCreatorId = item.NotiCreatorId,
                            AccessUserId = item.AccessUserId,
                            DetailId = item.DetailId,
                            IsSeen = (item.IsSeen != 0) ? true : false,
                            IsSent = true,
                            CreateDate = item.CreateDate,
                            NotiType = item.NotiType
                        };

                        await _repositoryWrapper.Notification.UpdateAsync(updatenoti, true);

                    }
                    else
                    {
                        return new { status = 0, mesage = "This NotiType Not Found" };
                    }
                }
                objresponse =newres;
                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

        
        [HttpPost("GetNotificationList", Name = "GetNotificationList")]
        public async Task<dynamic> GetNotificationList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            string userId = obj.UserId;
            int loginUserId=int.Parse(userId);
            
            try
            {
                dynamic res= await _repositoryWrapper.Notification.GetNotificationList(loginUserId);
                List<dynamic> newres=new List<dynamic> ();
                foreach (var item in res)
                {
                    if (item.NotiType == "MemberRequest")
                    {
                        var newnoti = new
                        {
                            NotiId = Encryption.EncryptID(item.NotiId.ToString(), loginUserId.ToString()),
                            Description = item.Description,
                            NotiType = item.NotiType,
                            DetailId = Encryption.EncryptID(item.DetailId.ToString(), loginUserId.ToString()),
                            SentDate = System.DateTime.Now
                        };
                        newres.Add(newnoti);
                    }
                    else
                    {
                        return new { status = 0, mesage = "This Noti Type Not Found" };
                    }
                }
                objresponse=newres;
                return objresponse;

            }
            catch (Exception ex)
            {
                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

        private bool CategoryExists(int id)
        {
            return _repositoryWrapper.Notification.IsExists(id);
        }
    }
}