using Dapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Dynamic;

namespace TodoApi.Models
{
  public class TodoContext : DbContext
  {

    private static readonly IConfiguration _configuration = Startup.StaticConfiguration!;
    private readonly string _connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Get<string>();
    public readonly IHttpContextAccessor _httpContextAccessor;
    public readonly IActionContextAccessor _actionContextAccessor;//use later

    public TodoContext(DbContextOptions<TodoContext> options,
        IHttpContextAccessor httpContextAccessor,
        IActionContextAccessor actionContextAccessor)
        : base(options)
    {
      _httpContextAccessor = httpContextAccessor;
      _actionContextAccessor = actionContextAccessor;
    }

    // public TodoContext(DbContextOptions<TodoContext> options)
    //     : base(options)
    // {
    // }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
    public DbSet<TodoItemDTO> TodoItemDTOs { get; set; } = null!;
    public DbSet<Hero> Heroes { get; set; } = null!;
    public DbSet<HeroDTO> HeroesDTO { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<AdminLevel> AdminLevels { get; set; } = null!;

    public DbSet<OTP> OTPs { get; set; } = null!;

    public DbSet<EventLog> EventLogs { get; set; } = null!;


    public async Task<int> RunExecuteNonQuery(string Query, ExpandoObject queryFilter)
    {
      if (queryFilter == null)
      {
        queryFilter = new ExpandoObject();
      }

      using (MySqlConnection conn = new(_connectionString))
      {
        var result = await conn.ExecuteAsync(Query, queryFilter);

        return result;
      }
    }

    public async Task<dynamic> RunExecuteSelectQuery(string Query, ExpandoObject? queryFilter = null)
    {
      if (queryFilter == null)
      {
        queryFilter = new ExpandoObject();
      }

      using (var conn = new MySqlConnection(_connectionString))
      {
        var result = await conn.QueryAsync(Query, queryFilter);
        return result;
      }
    }

    public async Task<List<T>> RunExecuteSelectQuery<T>(string Query, ExpandoObject? queryFilter = null)//acess admin retutn admin
    {
      if (queryFilter == null)
      {
        queryFilter = new ExpandoObject();
      }

      using (var conn = new MySqlConnection(_connectionString))
      {
        var result = await conn.QueryAsync<T>(Query, queryFilter);
        return result.ToList();
      }
    }
  }
}