
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace VibePass.Repository.Repositories;

public abstract class BaseRepository
{
    protected readonly IConfiguration _configuration;
    protected readonly IDbConnection _dbConnection;
    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreConnection"));
    }
}
