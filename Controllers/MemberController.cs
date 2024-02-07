using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public MemberController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("SentMemberRequest", Name = "SentMemberRequest")]
        public async Task<dynamic> SentMemberRequest([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            string userId = obj.UserId;
            string ClusterIdval = obj.ClusterIdval;
            string ApproverIdval = obj.ApproverIdval;
            int loginUserId = int.Parse(userId);
            int ClusterId = Convert.ToInt32(Encryption.DecryptID(ClusterIdval, userId));
            int ApproverId = Convert.ToInt32(Encryption.DecryptID(ApproverIdval, userId));

            try
            {
                var newmember = new InviteMember
                {
                    ClusterId = ClusterId,
                    RequesterId = loginUserId,
                    ApproverId = ApproverId,
                    CreateDate = System.DateTime.Now
                };
                await _repositoryWrapper.InviteMember.CreateAsync(newmember);
                await _repositoryWrapper.EventLog.Insert(newmember);
                var inviteMember = await _repositoryWrapper.InviteMember.FindByIDAsync(newmember.InviteId);
                if (inviteMember != null)
                {
                    var cluster = await _repositoryWrapper.Cluster.FindByIDAsync(ClusterId);
                    var admin = await _repositoryWrapper.Admin.FindByIDAsync(loginUserId);
                    if (cluster != null && admin != null)
                    {
                        string description = "Requested to you to be a member in " + cluster.ClusterName + " By " + admin.AdminName;
                        var newnoti = new Notification
                        {
                            Description = description,
                            NotiCreatorId = loginUserId,
                            AccessUserId = ApproverId,
                            DetailId = inviteMember.InviteId,
                            CreateDate = System.DateTime.Now,
                            NotiType="MemberRequest",
                        };
                        await _repositoryWrapper.Notification.CreateAsync(newnoti);
                        await _repositoryWrapper.EventLog.Insert(newmember);
                        objresponse = new { status = 1, message = "Invite Member Request Success" };
                    }
                    else
                    {
                        objresponse = new { status = 0, message = "Invite Member Request SomeWroung" };
                    }
                }
                else
                {
                    objresponse = new { status = 0, message = "Invite Member Request Fail" };
                }

                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

        [HttpPost("ResponseMemberRequest", Name = "ResponseMemberRequest")]
        public async Task<dynamic> ResponseMemberRequest([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            string userId = obj.UserId;
            string NotiIdval = obj.NotiIdval;
            string DetailIdval = obj.DetailIdval;
            int Status = obj.Status;
            int loginUserId = int.Parse(userId);
            int NotiId = Convert.ToInt32(Encryption.DecryptID(NotiIdval, userId));
            int DetailId = Convert.ToInt32(Encryption.DecryptID(DetailIdval, userId));

            try
            {
                var noti = await _repositoryWrapper.Notification.FindByIDAsync(NotiId);
                if (noti != null)
                {
                    var inviteMember = await _repositoryWrapper.InviteMember.FindByIDAsync(DetailId);
                    if (Status == 1)
                    {
                        if (inviteMember != null)
                        {
                            var user= await _repositoryWrapper.Admin.FindByIDAsync(loginUserId);
                            var newMember = new Member
                            {
                                UserId = loginUserId,
                                MemberName=user?.AdminName ?? "",
                                ClusterId = inviteMember.ClusterId,
                                Admin = false,
                                Commander = true,
                                Viewer = true,
                                Employee = true,
                                MemberDate = System.DateTime.Now,
                                Inactive = true
                            };

                            await _repositoryWrapper.Member.CreateAsync(newMember);
                            await _repositoryWrapper.EventLog.Insert(newMember);
                            var newMem = await _repositoryWrapper.Member.FindByIDAsync(newMember.MemberId);
                            if (newMem != null)
                            {
                                inviteMember.Access = true;
                                await _repositoryWrapper.InviteMember.UpdateAsync(inviteMember);
                                var cluster = await _repositoryWrapper.Cluster.FindByIDAsync(inviteMember.ClusterId);
                                var admin = await _repositoryWrapper.Admin.FindByIDAsync(loginUserId);
                                if (cluster != null && admin != null)
                                {
                                    string description = "Accessed to be a member in " + cluster.ClusterName + " By " + admin.AdminName;
                                    var newnoti = new Notification
                                    {
                                        Description = description,
                                        NotiCreatorId = loginUserId,
                                        AccessUserId = inviteMember.RequesterId,
                                        DetailId = inviteMember.InviteId,
                                        CreateDate = System.DateTime.Now,
                                        NotiType="MemberRequest",
                                    };
                                    await _repositoryWrapper.Notification.CreateAsync(newnoti);
                                    await _repositoryWrapper.EventLog.Insert(newnoti);
                                    await _repositoryWrapper.Notification.DeleteAsync(noti);
                                    objresponse = new { status = 1, message = "Access Successfully" };
                                }
                                else
                                {
                                    objresponse = new { status = 0, message = "Sorry,This Group Is Not Found" };
                                }
                            }
                            else
                            {
                                objresponse = new { status = 0, message = "Access Fail" };
                            }

                        }
                        else
                        {
                            objresponse = new { status = 0, message = "Sorry,This Group Is Not Found" };
                        }
                    }
                    else if (Status == 2)
                    {
                        if (inviteMember != null)
                        {
                            inviteMember.Reject = true;
                            await _repositoryWrapper.InviteMember.UpdateAsync(inviteMember);
                            var cluster = await _repositoryWrapper.Cluster.FindByIDAsync(inviteMember.ClusterId);
                            var admin = await _repositoryWrapper.Admin.FindByIDAsync(loginUserId);
                            if (cluster != null && admin != null)
                            {
                                string description = "Rejected to be a member in " + cluster.ClusterName + " By " + admin.AdminName;
                                var newnoti = new Notification
                                {
                                    Description = description,
                                    NotiCreatorId = loginUserId,
                                    AccessUserId = inviteMember.RequesterId,
                                    DetailId = inviteMember.InviteId,
                                    CreateDate = System.DateTime.Now,
                                    NotiType="MemberRequest",
                                };
                                await _repositoryWrapper.Notification.CreateAsync(newnoti);
                                await _repositoryWrapper.EventLog.Insert(newnoti);
                                await _repositoryWrapper.Notification.DeleteAsync(noti);
                                objresponse = new { status = 1, message = "Reject Successfully" };
                            }
                            else
                            {
                                objresponse = new { status = 0, message = "Sorry,This Group Is Not Found" };
                            }

                        }
                        else
                        {
                            objresponse = new { status = 0, message = "Sorry,This Group Is Not Found" };
                        }
                    }
                    else
                    {
                        objresponse = new { status = 0, message = "Please Select Access Or Reject" };
                    }
                }
                else
                {
                    objresponse = new { status = 0, message = "This Notification Not Found" };
                }
                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

    //Transcription
    [HttpPost("GetUserListInCluster", Name = "GetUserListInCluster")]
    public async Task<ActionResult<dynamic>> GetUserListInCluster([FromBody] Newtonsoft.Json.Linq.JObject param)
    {
      dynamic objresponse;
      dynamic obj=param;
      int CurRow=obj.Cur_Row;
      int limitRow=obj.limitRow;
      string userName=obj.UserName;
      string UserId=obj.UserId;
      string CategoryIdval=obj.CategoryIdval;
      int loginUserId=int.Parse(UserId);
      int CategoryId = Convert.ToInt32(Encryption.DecryptID(CategoryIdval, UserId));
      try
      {
        var category = await _repositoryWrapper.Category.FindByIDAsync(CategoryId);
        if (category != null)
        {
                int clusterId=category.ClusterId;
                var response= await _repositoryWrapper.Member.GetUserListInCluster(userName,clusterId,CurRow,limitRow,loginUserId);
                objresponse=response;
        }else{
            return NoContent();
        }
      }

      catch (Exception ex)
      {
        objresponse = new { data = ex.Message };
      }
      return objresponse;
    }

        private bool CategoryExists(int id)
        {
            return _repositoryWrapper.Collect.IsExists(id);
        }
    }
}