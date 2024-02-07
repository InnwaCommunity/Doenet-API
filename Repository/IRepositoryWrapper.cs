namespace TodoApi.Repositories
{
  public interface IRepositoryWrapper
  {
    IHeroRepository Hero { get; }
    IEmployeeRepository Employee { get; }
    ICustomerRepository Customer { get; }

    IAdminRepository Admin { get; }
    IAdminLevelRepository AdminLevel { get; }

    IOTPRepository OTP { get; }

    IEventLogRepository EventLog { get; }
    IClusterRepository Cluster {get;}

    ICategoryRepository Category {get;}

    IMemberRepository Member {get;}

    ICollectRepository Collect {get;}

    IUseReportRepository UseReport {get;}

    IInviteMemberRepository InviteMember {get;}

    INotificationRepository Notification {get;}

  }
}
