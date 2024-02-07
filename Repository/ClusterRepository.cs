
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoApi.Models;
using TodoApi.Util;
using training.Models;

namespace TodoApi.Repositories
{
    public class ClusterRepository : RepositoryBase<Cluster>, IClusterRepository
    {
        // private readonly IRepositoryWrapper _repository;
        public ClusterRepository(TodoContext repositoryContext) : base(repositoryContext) { }


        public async Task<List<GetClusterListComboResult>> GetClusterListByUserId(int userid)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.UserId = userid;
                string query = @"SELECT 
                                c.cluster_id as ClusterId, 
                                c.cluster_name as ClusterName, 
                                c.ispassword_use as IsPasswordUse, 
                                m.user_id as UserId, 
                                m.admin as Admin, 
                                m.commander as Commander, 
                                m.viewer as Viewer, 
                                m.employee as Employee, 
                                m.inactive as Inactive, 
                                c.cluster_create_date as CreateDate
                                FROM tbl_hc_member m 
                                JOIN tbl_hc_cluster c ON m.cluster_id = c.cluster_id
                                WHERE m.user_id = @userId
                                GROUP BY c.cluster_id, c.cluster_name, c.ispassword_use, m.user_id, m.admin, m.commander, m.viewer, m.employee, m.inactive, c.cluster_create_date;
                                ";

                List<GetClusterListComboResult> clusterList = await RepositoryContext.RunExecuteSelectQuery<GetClusterListComboResult>(query, parameters);


                return clusterList;
            }
            catch (Exception ex)
            {
                Log.Error("GetClusterCombo fail" + ex.Message);
                throw;
            }
        }

        public async Task<int> NumberOfMember(int clusterId)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.clusterId = clusterId;

                string query = @"SELECT COUNT(DISTINCT user_id) FROM tbl_hc_member WHERE cluster_id = @clusterId;";

                int num = await RepositoryContext.RunExecuteScalar<int>(query, parameters);


                return num;
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