
using System.Dynamic;
using Serilog;
using TodoApi.Models;
using TodoApi.Util;

namespace TodoApi.Repositories
{
    public class CollectRepository : RepositoryBase<Collect>, ICollectRepository
    {
        public CollectRepository(TodoContext repositoryContext) : base(repositoryContext) { }

        public async Task<dynamic> GetCollectReportList(int UserId, int CategoryId ,int curRow,int pageSize)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                curRow=curRow * pageSize;
                parameters.CategoryId=CategoryId;
                
                string query = @"SELECT 
                        c.collect_id as CollectId, 
                        c.collect_description as CollectDescription,
                        c.collect_value as CollectValue, 
                        c.collect_create_date as CollectDate,
                        c.command_count as CommandCount,
                        ad.admin_id as CollecterId,
                        ad.admin_name as CollecterName
                      FROM tbl_hc_collect c
                      JOIN tbl_hc_admin ad ON ad.admin_id = c.owner_id
                      WHERE c.category_id = @CategoryId";

                dynamic useReport = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                List<dynamic> mainQuery = new List<dynamic>();
                List<dynamic> response = new List<dynamic>();
                // Assuming useReport is a List<dynamic>
                mainQuery.AddRange(useReport);

                // Example: Skip the first row and take the next 15 rows
                mainQuery = mainQuery.Skip(curRow).Take(pageSize).ToList();
                foreach (var item in mainQuery)
                {
                    var newres = new
                    {
                        CollectId = Encryption.EncryptID(item.CollectId.ToString(), UserId.ToString()),
                        CollectDescription = item.CollectDescription,
                        CollectValue=item.CollectValue,
                        CollectDate=item.CollectDate,
                        CommandCount=item.CommandCount,
                        CollecterId=Encryption.EncryptID(item.CollecterId.ToString(), UserId.ToString()),
                        CollecterName = item.CollecterName
                    };
                    response.Add(newres);
                }
                return response;
                // return categoryList;
            }
            catch (Exception ex)
            {
                Log.Error("GetClusterCombo fail" + ex.Message);
                throw;
            }
        }
        //GetCollectReportOfLoginUser(int UserId,int CategoryId,int curRow,int pageSize)
        public async Task<dynamic> GetCollectReportOfLoginUser(int UserId, int CategoryId ,int curRow,int pageSize)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                curRow=curRow * pageSize;
                parameters.CategoryId=CategoryId;
                
                string query = @"SELECT 
                        c.collect_id as CollectId, 
                        c.collect_description as CollectDescription,
                        c.collect_value as CollectValue, 
                        c.collect_create_date as CollectDate,
                        c.command_count as CommandCount,
                        ad.admin_id as CollecterId,
                        ad.admin_name as CollecterName
                      FROM tbl_hc_collect c
                      JOIN tbl_hc_admin ad ON ad.admin_id = c.owner_id
                      WHERE c.category_id = @CategoryId && c.owner_id = @UserId";

                dynamic useReport = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                List<dynamic> mainQuery = new List<dynamic>();
                List<dynamic> response = new List<dynamic>();
                // Assuming useReport is a List<dynamic>
                mainQuery.AddRange(useReport);

                // Example: Skip the first row and take the next 15 rows
                mainQuery = mainQuery.Skip(curRow).Take(pageSize).ToList();
                foreach (var item in mainQuery)
                {
                    var newres = new
                    {
                        CollectId = Encryption.EncryptID(item.CollectId.ToString(), UserId.ToString()),
                        CollectDescription = item.CollectDescription,
                        CollectValue=item.CollectValue,
                        CollectDate=item.CollectDate,
                        CommandCount=item.CommandCount,
                        CollecterId=Encryption.EncryptID(item.CollecterId.ToString(), UserId.ToString()),
                        CollecterName = item.CollecterName
                    };
                    response.Add(newres);
                }
                return response;
            }
            catch (Exception ex)
            {
                Log.Error("GetClusterCombo fail" + ex.Message);
                throw;
            }
        }
        public bool IsExists(long id)
        {
            return RepositoryContext.Collects.Any(e => e.CollectId == id);
        }
    }
}