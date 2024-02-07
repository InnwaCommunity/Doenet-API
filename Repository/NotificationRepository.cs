
using System.Dynamic;
using Serilog;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(TodoContext repositoryContext) : base(repositoryContext) { }

        public async Task<dynamic> SentNotificationList(int loginUserId)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.loginUserId=loginUserId;
                
                string query = @"SELECT noti_id as NotiId,noti_description as Description,noti_creator_id as NotiCreatorId,access_user_id as AccessUserId, detail_id as DetailId,is_seen as IsSeen,is_sent as IsSent,create_date as CreateDate, noti_type as NotiType from tbl_notification WHERE access_user_id= @loginUserId &&  is_sent=false";

                dynamic notifications  = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                List<dynamic> mainQuery = new List<dynamic>();
                mainQuery.AddRange(notifications);
                return mainQuery;
            }
            catch (Exception ex)
            {
                Log.Error("Sent Notification List fail" + ex.Message);
                throw;
            }
        }

        public async Task<dynamic> GetNotificationList( int loginUserId)
        {
            try
            {
                dynamic parameters = new ExpandoObject();
                parameters.loginUserId=loginUserId;
                
                string query = @"SELECT noti_id as NotiId,noti_description as Description,noti_creator_id as NotiCreatorId,access_user_id as AccessUserId, detail_id as DetailId,is_seen as IsSeen,is_sent as IsSent,create_date as CreateDate, noti_type as NotiType from tbl_notification WHERE access_user_id= @loginUserId";

                dynamic notifications  = await RepositoryContext.RunExecuteSelectQuery<dynamic>(query, parameters);
                List<dynamic> mainQuery = new List<dynamic>();
                mainQuery.AddRange(notifications);
                return mainQuery;
            }
            catch (Exception ex)
            {
                Log.Error("Get Notification List fail" + ex.Message);
                throw;
            }
        }
        public bool IsExists(long id)
        {
            return RepositoryContext.Notifications.Any(e => e.NotiId == id);
        }
    }
}