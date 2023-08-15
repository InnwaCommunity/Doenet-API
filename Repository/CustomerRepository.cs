using System.Data;
using System.Linq;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using Serilog;

namespace TodoApi.Repositories
{
  public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
  {
    public CustomerRepository(TodoContext repositoryContext) : base(repositoryContext) { }
    public async Task<IEnumerable<Customer>> SearchCustomer(string searchTerm)
    {
      return await RepositoryContext.Customers.Where(s => s.CustomerName.Contains(searchTerm))
      .OrderBy(s => s.CustomerId).ToListAsync();
    }
    public async Task<IEnumerable<CustomerResult>> ListCustomer()
    {
      return await RepositoryContext.Customers.Select(e => new CustomerResult
      {
        CustomerId = e.CustomerId,
        CustomerName = e.CustomerName,
        CustomerAddress = e.CustomerAddress,
        CustomerTypeId = e.CustomerTypeId,
        CustomerTypeName = e.CustomerType!.CustypeName
      })
      .OrderBy(s => s.CustomerId).ToListAsync();
    }

    public async Task<List<CustomerSearchComboResult>> SearchCustomerCombo(string filter)
    {
      try
      {
        ExpandoObject queryfilter = new();
        queryfilter.TryAdd("@filter", "%" + filter + "%");
        queryfilter.TryAdd("@filterid", filter);

        var SelectQuery = @"Select c.customer_id as CustomerId,c.customer_name as CustomerName,c.customer_address as CustomerAddress
                          From tbl_customer c 
                          Where c.customer_name LIKE @filter OR c.customer_address LIKE @filter OR c.customer_id = @filterid 
                          ORDER BY c.customer_name LIMIT 0,5";

        List<CustomerSearchComboResult> custResult = await RepositoryContext.RunExecuteSelectQuery<CustomerSearchComboResult>(SelectQuery, queryfilter);

        return custResult;
      }
      catch (Exception ex)
      {
        Log.Error("GetCustomerCombo fail" + ex.Message);
        return new List<CustomerSearchComboResult>();
      }
    }
    public bool IsExists(long id)
    {
      return RepositoryContext.Customers.Any(e => e.CustomerId == id);
    }

  }

}