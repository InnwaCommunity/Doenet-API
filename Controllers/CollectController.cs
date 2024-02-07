using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public CollectController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpPost("SaveCollectReport", Name = "SaveCollectReport")]
        public async Task<dynamic> SaveCollectReport([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            try
            {
                string categoryIdval = obj.CategoryIdval;
                string UserId = obj.UserId;
                string OwnerIdval=obj.OwnerIdval;
                int LoginUserId = int.Parse(UserId);
                int CategoryId = Convert.ToInt32(Encryption.DecryptID(categoryIdval, UserId));
                int OwnerId= Convert.ToInt32(Encryption.DecryptID(OwnerIdval, UserId));
                var newobj = new Collect
                {
                    CollectDescription = obj.CollectDescription,
                    CollectValue= obj.CollectValue,
                    CategoryId=CategoryId,
                    OwnerId=OwnerId,
                    PosterId=LoginUserId,
                    CreateDate= DateTime.Now,
                    ModifiedDate= DateTime.Now
                };
                await _repositoryWrapper.Collect.CreateAsync(newobj);
                await _repositoryWrapper.EventLog.Insert(newobj);
                var collectReport = await _repositoryWrapper.Collect.FindByIDAsync(newobj.CollectId);
                if (collectReport != null)
                {
                    var category = await _repositoryWrapper.Category.FindByIDAsync(CategoryId);
                    if (category != null)
                    {
                        int collectValue=obj.CollectValue;
                        category.Total=category.Total + collectValue;
                        category.LastBalance = category.LastBalance + collectValue;

                        await _repositoryWrapper.Category.UpdateAsync(category, true);
                        objresponse = "Save Successfully";
                    }
                    else
                    {
                        objresponse = "Save Fail";
                    }
                }
                else
                {
                    objresponse = "Save Fail";
                }

                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

        [HttpPost("GetCollectReportList", Name = "GetCollectReportList")]
        public async Task<dynamic> GetCollectReportList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            string categoryIdval = obj.CategoryIdval;
            string userId = obj.UserId;
            int cur_Row = obj.Cur_Row;
            int pageSize=obj.pageSize;
            int UserId = int.Parse(userId);
            int CategoryId = Convert.ToInt32(Encryption.DecryptID(categoryIdval, userId));
            try
            {
                var cate = await _repositoryWrapper.Category.FindByIDAsync(CategoryId);
                if (cate != null)
                {
                    var mem = await _repositoryWrapper.Member.FindByConditionAsync(m => m.UserId == UserId && m.ClusterId == cate.ClusterId);
                    if (mem != null && mem.Any())
                    {

                        if (mem.Any(m => m.Admin))
                        {
                            var res = await _repositoryWrapper.Collect.GetCollectReportList(UserId,CategoryId,cur_Row,pageSize);
                            objresponse=new {status = 1, data = res};
                        }else{
                            var res = await _repositoryWrapper.Collect.GetCollectReportOfLoginUser(UserId,CategoryId,cur_Row,pageSize);
                            objresponse=new {status = 1, data = res};
                        }
                    }else{
                        objresponse=new {status = 0, error = "There is No found This Member"};
                    }
                }else{
                   objresponse=new {status = 0, error = "There is No found This Category"};
                }
                

                

                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }


        [HttpPost("GetCollectPossessValue", Name = "GetCollectPossessValue")]
        public async Task<dynamic> GetCollectPossessValue([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            string categoryIdval = obj.CategoryIdval;
            string userId = obj.UserId;
            int UserId = int.Parse(userId);
            int possessValue=0;
            int CategoryId = Convert.ToInt32(Encryption.DecryptID(categoryIdval, userId));
            try
            {
                var cate = await _repositoryWrapper.Category.FindByIDAsync(CategoryId);
                if (cate != null)
                {
                    var coll = await _repositoryWrapper.Collect.FindByConditionAsync(c => c.OwnerId == UserId && c.CategoryId == CategoryId);
                    if (coll != null)
                    {
                        foreach (var item in coll)
                        {
                            possessValue = item.CollectValue + possessValue;
                        }
                        objresponse = new { status = 1,Total=cate.Total, PossessValue = possessValue };
                    }
                    else
                    {
                        objresponse = new { status = 0, error = "There is No found This Collect" };
                    }
                }
                else
                {
                    objresponse = new { status = 0, error = "There is No found This Category" };
                }
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
            return _repositoryWrapper.Collect.IsExists(id);
        }
    }
}