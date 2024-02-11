

using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;
using TodoApi.Util;
using training.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterController : BaseController
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ClusterController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("CreateCluster", Name = "CreateCluster")]
        public async Task<dynamic> CreateCluster([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            var clusterdata = new Cluster();
            dynamic obj = param;
            try
            {
                var newobj = new Cluster
                {
                    ClusterName = obj.ClusterName,
                    IsPasswordUse = obj.IsPasswordUse,
                    Password = obj.Password,
                    Inactive = false,
                    CreateDate = System.DateTime.Now,
                    ModifiedDate = System.DateTime.Now
                };
                var ispassword_use = newobj.IsPasswordUse;
                int UserId = obj.CreatorIdval;
                // int LoginEmpID = Convert.ToInt32(_tokenData.UserID);
                // int team = Convert.ToInt32(Encryption.DecryptID(obj.AssignIDval.ToString(),LoginEmpID.ToString()));
                var password = newobj.Password;
                if (ispassword_use)
                {
                    string salt = Util.SaltedHash.GenerateSalt();
                    password = Util.SaltedHash.ComputeHash(salt, password.ToString());
                    newobj.Password = password;
                    newobj.Salt = salt;
                    Validator.ValidateObject(newobj, new ValidationContext(newobj), true);
                    //  _repositoryWrapper.Admin.CreateAsync(newobj);
                    await _repositoryWrapper.Cluster.CreateAsync(newobj);
                    await _repositoryWrapper.EventLog.Insert(newobj);
                    var cluster = await _repositoryWrapper.Cluster.FindByIDAsync(newobj.ClusterId);
                    if (cluster != null)
                    {
                        clusterdata = cluster;
                    }
                    else
                    {
                        clusterdata = null;
                    }
                }
                else
                {
                    Validator.ValidateObject(newobj, new ValidationContext(newobj), true);
                    //  _repositoryWrapper.Admin.CreateAsync(newobj);
                    await _repositoryWrapper.Cluster.CreateAsync(newobj);
                    await _repositoryWrapper.EventLog.Insert(newobj);
                    var cluster = await _repositoryWrapper.Cluster.FindByIDAsync(newobj.ClusterId);
                    if (cluster != null)
                    {
                        clusterdata = cluster;
                    }
                    else
                    {
                        clusterdata = null;
                    }
                }
                if (clusterdata != null)
                {
                    Cluster cluster = clusterdata;
                    // int LoginEmpID = Convert.ToInt32(_tokenData.UserID);
                    // String LoginEmpName=_tokenData.UserName;
                    // String objStart=obj.StartDate;
                    // String objEnd = obj.EndDate;
                    // DateTime startDate= Globalfunction.ConvertStringToDateTime(objStart);
                    // DateTime endDate = Globalfunction.ConvertStringToDateTime(objEnd);
                    // var catobj = new Category
                    // {
                    //     CategoryName=obj.CategoryName,
                    //     CategoryId= cluster.ClusterId,
                    //     Total = obj.Total,
                    //     LastBalance = 0,
                    //     StartDate = startDate,
                    //     EndDate = endDate,
                    // };
                    // Validator.ValidateObject(catobj, new ValidationContext(catobj), true);
                    // await _repositoryWrapper.Category.CreateAsync(catobj);
                    // await _repositoryWrapper.EventLog.Insert(catobj);
                    var user= await _repositoryWrapper.Admin.FindByIDAsync(UserId);
                    string? memName=user?.AdminName;
                    var member = new Member
                    {
                        UserId = UserId,
                        MemberName=memName ?? "",
                        ClusterId = cluster.ClusterId,
                        Admin = true,
                        Commander = true,
                        Viewer = true,
                        Employee = true,
                        MemberDate = System.DateTime.Now,
                        Inactive = false
                    };
                    Validator.ValidateObject(member, new ValidationContext(member), true);
                    await _repositoryWrapper.Member.CreateAsync(member);
                    await _repositoryWrapper.EventLog.Insert(member);

                    // var category = await _repositoryWrapper.Category.FindByIDAsync(catobj.CategoryId);
                    // if (category != null)
                    // {
                    //     int CategoryId=category.CategoryId;
                    //     var collObj= new Collect
                    //     {
                    //         CollectDescription=obj.CollectDescription,
                    //         OwnerId=obj.OwnerId,
                    //         PosterId=LoginEmpID,
                    //         CollectValue=obj.CollectValue,
                    //         CategoryId = CategoryId,
                    //         ClusterId =cluster.ClusterId,
                    //         CreateDate= System.DateTime.Now,
                    //         ModifiedDate =System.DateTime.Now
                    //     };
                    // }else{
                    //     objresponse="Fail Create Cluster";
                    //     return objresponse;
                    // }
                    objresponse = "Cluster Create Successfully";
                }
                else
                {
                    // await _repositoryWrapper.Cluster.
                    objresponse = "Fail Create Cluster";
                }

            }
            catch (Exception ex)
            {

                objresponse = new { data = ex.Message };
            }
            return objresponse;
        }

        [HttpPost("GetClusterList", Name = "GetClusterList")]
        public async Task<dynamic> GetClusterList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse;
            var clusterdata = new Cluster();
            dynamic obj = param;
            try
            {
                string data=obj.UserId;
                int UserId = int.Parse(data);
                var res = await _repositoryWrapper.Cluster.GetClusterListByUserId(UserId);
                var newres = new List<dynamic>();
                foreach (var item in res)
                {
                    int numOfMembers= await _repositoryWrapper.Cluster.NumberOfMember(item.ClusterId);
                    var newcluster = new
                    {
                        ClusterIdval = Encryption.EncryptID(item.ClusterId.ToString(), item.UserId.ToString()),
                        ClusterName = item.ClusterName,
                        IsPasswordUse = item.IsPasswordUse,
                        Admin = item.Admin,
                        Commander = item.Commander,
                        Viewer = item.Viewer,
                        Employee = item.Employee,
                        Inactive = item.Inactive,
                        NumOfMembers = numOfMembers,
                        CreateDate = item.CreateDate
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

        [HttpPost("ValidateClusterPassword", Name = "ValidateClusterPassword")]
        public async Task<dynamic> ValidateClusterPassword([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            
            dynamic obj = param;
            var password=obj.Password;
            string ClusterIdval=obj.ClusterIdval;
            string UserId=obj.UserId;
            int ClusterId = Convert.ToInt32(Encryption.DecryptID(ClusterIdval,UserId));
            try
            {
                var objCluster = await _repositoryWrapper.Cluster.FindByIDAsync(ClusterId);
                if (objCluster == null)
                    throw new ValidationException("This Cluster not found.");

                string oldsalt = objCluster.Salt;
                string oldhash = objCluster.Password;
                bool flag = SaltedHash.Verify(oldsalt, oldhash, password.ToString());

                if (flag == false)  //incorrect pwd
                {
                    throw new Exception("Incorrect Password info for this cluster : ");
                }
                else
                {
                    return new { error = 0, data = "Correct Password!" };
                }
            }
            catch (ValidationException vex)
            {
                return new { error = 1, message = vex.Message };
            }
            catch (Exception)
            {
                return new { error = 1, message = "Check Password Fail" };
            }
        }



        // [HttpPost("SetUpCluster", Name = "SetUpCluster")]
        // public async Task<dynamic> SetUpCluster([FromBody] Newtonsoft.Json.Linq.JObject param){

        // }

        private bool AdminExists(int id)
        {
            return _repositoryWrapper.Admin.IsExists(id);
        }
    }
}