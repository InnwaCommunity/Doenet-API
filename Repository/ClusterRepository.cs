
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
                // dynamic parameters = new ExpandoObject();
                // parameters.UserId = userid;

                // var query = "SELECT c.cluster_id as ClusterId,c.cluster_name as ClusterName,c.ispassword_use as IsPasswordUse,m.user_id as UserId,m.admin as Admin,m.commander as Commander,m.viewer as Viewer,m.employee as Employee,m.inactive as Inactive,c.cluster_create_date as CreateDate FROM tbl_member m JOIN tbl_cluster c ON m.cluster_id = c.cluster_id WHERE m.user_id = @userid";

                // List<GetClusterListComboResult> clusterList = await RepositoryContext.RunExecuteSelectQuery<GetClusterListComboResult>(query, parameters);
                dynamic parameters = new ExpandoObject();
                parameters.UserId = userid;

                // var query = "SELECT c.cluster_id as ClusterId, c.cluster_name as ClusterName, c.ispassword_use as IsPasswordUse, m.user_id as UserId, m.admin as Admin, m.commander as Commander, m.viewer as Viewer, m.employee as Employee, m.inactive as Inactive, c.cluster_create_date as CreateDate FROM tbl_member m JOIN tbl_cluster c ON m.cluster_id = c.cluster_id WHERE m.user_id = @userid";
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
                        c.cluster_create_date as CreateDate,
                        (SELECT COUNT(DISTINCT UserId) FROM tbl_member WHERE cluster_id = c.cluster_id) as NumOfMembers
                      FROM tbl_member m 
                      JOIN tbl_cluster c ON m.cluster_id = c.cluster_id 
                      WHERE m.user_id = @userId";

                List<GetClusterListComboResult> clusterList = await RepositoryContext.RunExecuteSelectQuery<GetClusterListComboResult>(query, parameters);


                return clusterList;
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