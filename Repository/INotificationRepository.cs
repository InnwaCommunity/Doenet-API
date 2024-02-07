
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
       Task<dynamic> SentNotificationList(int loginUserId);
       Task<dynamic> GetNotificationList( int loginUserId);
        bool IsExists(long id);
    }
}