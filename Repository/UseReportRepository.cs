
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoApi.Models;
using TodoApi.Util;
using training.Models;

namespace TodoApi.Repositories
{
    public class UseReportRepository : RepositoryBase<UseReport>, IUseReportRepository
    {
        // private readonly IRepositoryWrapper _repository;
        public UseReportRepository(TodoContext repositoryContext) : base(repositoryContext) { }

        public async Task<dynamic> GetUseReportList(int UserId, int CategoryId ,int curRow,int pageSize)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                curRow=curRow * pageSize;
                parameters.CategoryId=CategoryId;
                
                string query = @"SELECT 
                        ur.report_id as ReportId, 
                        ur.report_description as ReportDescription,
                        ur.use_amount as UseAmount, 
                        ur.report_date as ReportDate,
                        ur.command_count as CommandCount,
                        ad.admin_id as ReporterId,
                        ad.admin_name as ReporterName
                      FROM tbl_hc_usereport ur
                      JOIN tbl_hc_admin ad ON ad.admin_id = ur.member_id
                      WHERE ur.category_id = @CategoryId";

                dynamic useReport = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                List<dynamic> mainQuery = new List<dynamic>();

                // Assuming useReport is a List<dynamic>
                mainQuery.AddRange(useReport);

                // Example: Skip the first row and take the next 15 rows
                mainQuery = mainQuery.Skip(curRow).Take(pageSize).ToList();
                return mainQuery;
                // return categoryList;
            }
            catch (Exception ex)
            {
                Log.Error("GetClusterCombo fail" + ex.Message);
                throw;
            }
        }


        public bool IsExists(long id)
        {
            return RepositoryContext.Clusters.Any(e => e.ClusterId == id);
        }
    }
}