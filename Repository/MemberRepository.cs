
using System.Dynamic;
using TodoApi.Models;
using TodoApi.Util;

namespace TodoApi.Repositories
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(TodoContext repositoryContext) : base(repositoryContext) { }
        public bool IsExists(long id)
        {
            return RepositoryContext.Members.Any(e => e.MemberId == id);
        }
        
    public async Task<dynamic> GetUserListInCluster(string username,int clusterId, int curRow, int limitRow, int loginUserid)
    {

      dynamic parameters = new ExpandoObject();
      parameters.username = username;
      parameters.clusterId=clusterId;
      parameters.loginUserid=loginUserid;
      string query = "SELECT user_id as UserId, member_name as UserName " +
                   "FROM tbl_hc_member " +
                   "WHERE member_name LIKE CONCAT(@username, '%') " +
                   "AND cluster_id = @clusterId " +
                   "AND user_id != @loginUserid " + 
                   "ORDER BY member_name ASC;";

      dynamic userList = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
      List<dynamic> mainQuery = new List<dynamic>();
      List<dynamic> response = new List<dynamic>();
      mainQuery.AddRange(userList);
      mainQuery = mainQuery.Skip(curRow).Take(limitRow).ToList();
      foreach (var item in mainQuery)
      {
        var newres = new
        {
          UserIdval = Encryption.EncryptID(item.UserId.ToString(), loginUserid.ToString()),
          UserName = item.UserName
        };
        response.Add(newres);
      }
      return response;
    }
    }
}