using TodoApi.Models;

namespace TodoApi.Repositories
{
  public interface ICustomerRepository : IRepositoryBase<Customer>
  {
    Task<IEnumerable<Customer>> SearchCustomer(string searchName);
    Task<IEnumerable<CustomerResult>> ListCustomer();

    Task<List<CustomerSearchComboResult>> SearchCustomerCombo(string filter);
    bool IsExists(long id);
  }
}