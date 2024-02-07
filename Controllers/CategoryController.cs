using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public CategoryController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpPost("CreateCategory", Name = "CreateCategory")]
        public async Task<dynamic> CreateCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            try
            {
                string startDateString = obj.StartDate;
                string endDateString = obj.EndDate;
                string ClusterIdval = obj.ClusterIdval;
                string UserId = obj.UserId;
                int ClusterId = Convert.ToInt32(Encryption.DecryptID(ClusterIdval, UserId));
                var newobj = new Category
                {
                    CategoryName = obj.CategoryName,
                    ClusterId = ClusterId,
                    Total = obj.CollectValue,
                    LastBalance = 0,
                    StartDate = DateTime.Parse(startDateString),
                    EndDate = DateTime.Parse(endDateString)
                };
                await _repositoryWrapper.Category.CreateAsync(newobj);
                await _repositoryWrapper.EventLog.Insert(newobj);
                var category = await _repositoryWrapper.Category.FindByIDAsync(newobj.CategoryId);
                if (category != null)
                {
                    string OwnerIdval = obj.OwnerIdval;
                    int PosterId = int.Parse(UserId);
                    int OwnerId = Convert.ToInt32(Encryption.DecryptID(OwnerIdval, UserId));
                    var newCollect = new Collect
                    {
                        CollectDescription = obj.CollectDescription,
                        OwnerId = OwnerId,
                        PosterId = PosterId,
                        CollectValue = obj.CollectValue,
                        CategoryId = category.CategoryId,
                        CreateDate = System.DateTime.Now,
                        ModifiedDate = System.DateTime.Now
                    };
                    await _repositoryWrapper.Collect.CreateAsync(newCollect);
                    await _repositoryWrapper.EventLog.Insert(newCollect);
                    var collect = await _repositoryWrapper.Collect.FindByIDAsync(newCollect.CollectId);
                    if (category != null)
                    {
                        objresponse = "Create Category Successfully!";
                    }
                    else
                    {
                        objresponse = "Add Collect Fail";
                    }
                }
                else
                {
                    objresponse = "Create Category Fail";
                }

                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }


        [HttpPost("AddCollectValue", Name = "AddCollectValue")]
        public async Task<dynamic> AddCollectValue([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            dynamic obj = param;
            try
            {
                int OwnerId = Convert.ToInt32(Encryption.DecryptID(obj.OwnerIdval, obj.UserId));
                int PosterId = int.Parse(obj.UserId);
                var newCollect = new Collect
                {
                    CollectDescription = obj.CollectDescription,
                    OwnerId = OwnerId,
                    PosterId = PosterId,
                    CollectValue = obj.CollectValue,
                    CategoryId = obj.CategoryId,
                    CreateDate = System.DateTime.Now,
                    ModifiedDate = System.DateTime.Now
                };
                await _repositoryWrapper.Category.CreateAsync(newCollect);
                await _repositoryWrapper.EventLog.Insert(newCollect);
                var category = await _repositoryWrapper.Category.FindByIDAsync(newCollect.CategoryId);
                if (category != null)
                {
                    objresponse = "Add Collect Successfully!";
                }
                else
                {
                    objresponse = "Add Collect Fail";
                }

                return objresponse;

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

        [HttpPost("GetCategoryList", Name = "GetCategoryList")]
        public async Task<dynamic> GetCategoryList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            var clusterdata = new Category();
            dynamic obj = param;
            try
            {
                string data=obj.UserId;
                string categoryval=obj.ClasterIdval;
                int CategoryId=Convert.ToInt32(Encryption.DecryptID(categoryval, data));
                int UserId = int.Parse(data);
                var res = await _repositoryWrapper.Category.GetCategoryListByUserId(UserId,CategoryId);
                // var newres = new List<dynamic>();
                // foreach (var item in res)
                // {
                //     var newcategory = new
                //     {
                //         CategoryIdval = Encryption.EncryptID(item.CategoryId.ToString(), UserId.ToString()),
                //         CategoryName = item.CategoryName,
                //         Total = item.Total,
                //         LastBalance = item.LastBalance,
                //         StartDate = item.StartDate,
                //         EndDate = item.EndDate
                //     };

                //     newres.Add(newcategory);
                // }
                objresponse = res;

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
            return _repositoryWrapper.Category.IsExists(id);
        }
    }
}