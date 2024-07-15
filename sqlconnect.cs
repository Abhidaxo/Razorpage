using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApplication2.model;

public class YourEntityRepository
{
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;
    public YourEntityRepository(IConfiguration configuration)
    {
        _configuration= configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    private IDbConnection Connection => new MySqlConnection(_connectionString);

    public async Task<IEnumerable<products>> GetAllAsync()
    {
        using (var dbConnection = Connection)
        {
            string query = "SELECT * FROM products";
            dbConnection.Open();
            return await dbConnection.QueryAsync<products>(query);
        }
    }

    public async Task<YourEntity> GetByIdAsync(string username )
    {
        using (var dbConnection = Connection)
        {
            string query = "SELECT * FROM employelogin WHERE username = @username ";
            dbConnection.Open();
            return await dbConnection.QueryFirstOrDefaultAsync<YourEntity>(query, new { username = username });
        }
    }

    public async Task AddAsync(YourEntity entity)
    {
        using (var dbConnection = Connection)
        {
            string query = "INSERT INTO employelogin (username,email,password) VALUES (@username ,@email,@password)";
            dbConnection.Open();
            await dbConnection.ExecuteAsync(query, entity);
        }
    }

    public async Task AddProductAsync(products entity)
    {
        using (var dbConnection = Connection)
        {
            string query = "INSERT INTO products (product_name,price,quantity) VALUES (@product_name,@price,@quantity)";
            dbConnection.Open();
            await dbConnection.ExecuteAsync(query, entity);
        }
    }

    public async Task UpdateAsync(YourEntity entity)
    {
        using (var dbConnection = Connection)
        {
            string query = "UPDATE YourEntities SET Name = @Name WHERE Id = @Id";
            dbConnection.Open();
            await dbConnection.ExecuteAsync(query, entity);
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (var dbConnection = Connection)
        {
            string query = "DELETE FROM products WHERE product_Id = @Id";
            dbConnection.Open();
            await dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
    public async Task CheckAsync( YourEntity entity)
    {

        using (var dbConnection = Connection)
        {
            string query = " select exists ( select 1 from employelogin where username = @username and password = @password)";
            dbConnection.Open();
            await dbConnection.ExecuteAsync(query, entity);
        }
    }
}
public class YourEntity
{
    public string username { get; set; }
    public string email { get; set; }

    public string password { get; set; }    
    // Other properties
}

