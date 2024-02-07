
using System.Dynamic;
using Serilog;
using TodoApi.Models;
using TodoApi.Util;

namespace TodoApi.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(TodoContext repositoryContext) : base(repositoryContext) { }

        public async Task<dynamic> GetCategoryListByUserId(int UserId, int ClusterId)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.UserId = UserId;
                parameters.ClusterId=ClusterId;

                string query = @"SELECT 
                        c.category_id as CategoryId, 
                        c.category_name as CategoryName,
                        c.total as Total, 
                        c.last_balance as LastBalance, 
                        c.start_date as StartDate, 
                        c.end_date as EndDate
                      FROM tbl_hc_member m 
                      JOIN tbl_hc_category c ON m.cluster_id = c.cluster_id
                      WHERE m.user_id = @UserId AND c.cluster_id = @ClusterId";

                dynamic categoryList = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                var newres = new List<dynamic>();
                foreach (var item in categoryList)
                {
                    var newuseList = new List<dynamic>();
                    DateTime currentDate = item.StartDate;
                    while (currentDate <= item.EndDate)
                    {
                        Console.WriteLine(currentDate);
                        
                        var useageList= await GetUserReportList(item.CategoryId,currentDate);
                        currentDate = currentDate.AddDays(1);
                        newuseList.Add(useageList);
                    }
                    var newcategory = new
                    {
                        CategoryIdval = Encryption.EncryptID(item.CategoryId.ToString(), UserId.ToString()),
                        CategoryName = item.CategoryName,
                        Total = item.Total,
                        LastBalance = item.LastBalance,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        UsageReportList=newuseList
                    };

                    newres.Add(newcategory);
                }
                return newres;

                // return categoryList;
            }
            catch (Exception ex)
            {
                Log.Error("GetClusterCombo fail" + ex.Message);
                throw;
            }
        }

        
        public async Task<dynamic> GetUserReportList(int CategoryId, DateTime currentDate)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.CategoryId = CategoryId;
                parameters.currentDate=currentDate;

                string query = @"SELECT 
                        report_date as ReportDate,
                        use_amount as UseAmount
                      FROM tbl_hc_usereport
                      WHERE category_id = @CategoryId AND  DATE(report_date) = DATE(@currentDate)";

                dynamic useReport = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                var newres = new
                {
                    ReportDate = currentDate.ToString("yyyy-MM-dd"), // Default value for ReportDate
                    UseAmount = 0 // Default value for UseAmount
                };

                if (useReport.Count > 0)
                {
                    List<dynamic> newRe=(List<dynamic>)useReport;
                    int UseAmount=0;
                    DateTime reportDate=currentDate;
                    foreach (var use in newRe)
                    {
                        reportDate=(DateTime)use.ReportDate;
                        int newUseAmount=(int)use.UseAmount;
                        UseAmount=UseAmount+newUseAmount;
                    }
                    newres = new
                    {
                        ReportDate = reportDate.ToString("yyyy-MM-dd"),
                        UseAmount = (int)UseAmount
                    };
                }
                return newres;
            }
            catch (Exception ex)
            {
                Log.Error("GetClusterCombo fail" + ex.Message);
                throw;
            }
        }

        public bool IsExists(long id)
        {
            return RepositoryContext.Categories.Any(e => e.CategoryId == id);
        }
    }
}