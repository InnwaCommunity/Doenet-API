using TodoApi.Models;
namespace TodoApi.Repositories
{
  public class RepositoryWrapper : IRepositoryWrapper
  {
    private readonly TodoContext _repoContext;

    public RepositoryWrapper(TodoContext repositoryContext)
    {
      _repoContext = repositoryContext;
    }

    private IHeroRepository? oHero;
    public IHeroRepository Hero
    {
      get
      {
        if (oHero == null)
        {
          oHero = new HeroRepository(_repoContext);
        }

        return oHero;
      }
    }
    private IEmployeeRepository? oEmployee;
    public IEmployeeRepository Employee
    {
      get
      {
        if (oEmployee == null)
        {
          oEmployee = new EmployeeRepository(_repoContext);
        }
        return oEmployee;
      }

    }

    private ICustomerRepository? oCustomer;
    public ICustomerRepository Customer
    {
      get
      {
        if (oCustomer == null)
        {
          oCustomer = new CustomerRepository(_repoContext);
        }
        return oCustomer;
      }

    }

    private IAdminRepository? oAdmin;
    public IAdminRepository Admin
    {
      get
      {
        if (oAdmin == null)
        {
          oAdmin = new AdminRepository(_repoContext);
        }
        return oAdmin;
      }

    }

    private IAdminLevelRepository? oAdminLevel;
    public IAdminLevelRepository AdminLevel
    {
      get
      {
        if (oAdminLevel == null)
        {
          oAdminLevel = new AdminLevelRepository(_repoContext);
        }
        return oAdminLevel;
      }

    }

    private IOTPRepository? oOTP;
    public IOTPRepository OTP
    {
      get
      {
        if (oOTP == null)
        {
          oOTP = new OTPRepository(_repoContext);
        }
        return oOTP;
      }

    }

    private IEventLogRepository? oEventLog;
    public IEventLogRepository EventLog
    {
      get
      {
        if (oEventLog == null)
        {
          oEventLog = new EventLogRepository(_repoContext);
        }
        return oEventLog;
      }

    }

    
    private IClusterRepository? oCluster;
    public IClusterRepository Cluster
    {
      get
      {
        if (oCluster == null)
        {
          oCluster = new ClusterRepository(_repoContext);
        }
        return oCluster;
      }
    }
    private ICategoryRepository? oCategory;
    public ICategoryRepository Category
    {
      get
      {
        if (oCategory == null)
        {
          oCategory = new CategoryRepository(_repoContext);
        }
        return oCategory;
      }
    }
    private IMemberRepository? oMember;
    public IMemberRepository Member
    {
      get
      {
        if (oMember == null)
        {
          oMember = new MemberRepository(_repoContext);
        }
        return oMember;
      }
    }

    
    private ICollectRepository? oCollect;
    public ICollectRepository Collect
    {
      get
      {
        if (oCollect == null)
        {
          oCollect = new CollectRepository(_repoContext);
        }
        return oCollect;
      }
    }
  }
}