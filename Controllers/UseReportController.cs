using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseReportController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public UseReportController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpPost("SaveUseReport", Name = "SaveUseReport")]
        public async Task<dynamic> SaveUseReport([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            try
            {
                string categoryIdval = obj.CategoryIdval;
                string UserId = obj.UserId;
                int MemberId = int.Parse(UserId);
                DateTime? reportDate = obj.ReportDate;
                int CategoryId = Convert.ToInt32(Encryption.DecryptID(categoryIdval, UserId));
                var newobj = new UseReport
                {
                    ReportDescription = obj.ReportDescription,
                    UseAmount= obj.UseAmount,
                    CategoryId=CategoryId,
                    MemberId=MemberId,
                    ReportDate= reportDate ?? DateTime.Now
                };
                await _repositoryWrapper.UseReport.CreateAsync(newobj);
                await _repositoryWrapper.EventLog.Insert(newobj);
                var useReport = await _repositoryWrapper.UseReport.FindByIDAsync(newobj.ReportId);
                if (useReport != null)
                {
                    var category = await _repositoryWrapper.Category.FindByIDAsync(CategoryId);
                    if (category != null)
                    {
                        int usevalue=obj.UseAmount;
                        category.LastBalance = category.LastBalance - usevalue;

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


        // [HttpPost("AddCollectValue", Name = "AddCollectValue")]
        // public async Task<dynamic> AddCollectValue([FromBody] Newtonsoft.Json.Linq.JObject param)
        // {
        //     dynamic objresponse;
        //     dynamic obj = param;
        //     try
        //     {
        //         int OwnerId = Convert.ToInt32(Encryption.DecryptID(obj.OwnerIdval, obj.UserId));
        //         int PosterId = int.Parse(obj.UserId);
        //         var newCollect = new Collect
        //         {
        //             CollectDescription = obj.CollectDescription,
        //             OwnerId = OwnerId,
        //             PosterId = PosterId,
        //             CollectValue = obj.CollectValue,
        //             CategoryId = obj.CategoryId,
        //             ClusterId = obj.ClusterId,
        //             CreateDate = System.DateTime.Now,
        //             ModifiedDate = System.DateTime.Now
        //         };
        //         await _repositoryWrapper.Category.CreateAsync(newCollect);
        //         await _repositoryWrapper.EventLog.Insert(newCollect);
        //         var category = await _repositoryWrapper.Category.FindByIDAsync(newCollect.CategoryId);
        //         if (category != null)
        //         {
        //             objresponse = "Add Collect Successfully!";
        //         }
        //         else
        //         {
        //             objresponse = "Add Collect Fail";
        //         }

        //         return objresponse;

        //     }
        //     catch (Exception ex)
        //     {

        //         objresponse = new { data = ex.Message };
        //     }
        //     return objresponse;
        // }

        [HttpPost("GetUseReportList", Name = "GetUseReportList")]
        public async Task<dynamic> GetUseReportList([FromBody] Newtonsoft.Json.Linq.JObject param)
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
                var res = await _repositoryWrapper.UseReport.GetUseReportList(UserId,CategoryId,cur_Row,pageSize);

                var newres = new List<dynamic>();
                foreach (var item in res)
                {
                    var newcluster = new
                    {
                        ReportIdval = Encryption.EncryptID(item.ReportId.ToString(), UserId.ToString()),
                        ReportDescription = item.ReportDescription,
                        UseAmount = item.UseAmount,
                        ReportDate = item.ReportDate,
                        CommandCount = item.CommandCount,
                        ReporterIdval = Encryption.EncryptID(item.ReporterId.ToString(), UserId.ToString()),
                        ReporterName = item.ReporterName
                    };

                    newres.Add(newcluster);
                }
                objresponse = newres;

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
            return _repositoryWrapper.UseReport.IsExists(id);
        }
    }
}