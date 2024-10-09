using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Models;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class EventyRepository : BaseRepository, IEventyRepository
{
    public EventyRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<List<EventyResponse>> GetAllAsync()
    {
        var query = "SELECT * FROM Events";
        var records = await _dbConnection.QueryAsync<EventyResponse>(query);
        return records.ToList();
    }

    public async Task<EventyResponse> GetByIdAsync(string id)
    {
        var query = "SELECT * FROM Events WHERE Id = @Id";
        var record = await _dbConnection.QueryFirstOrDefaultAsync<EventyResponse>(query, id);
        return record;
    }

    public async Task<List<EventyResponse>> GetListAsync(int offset, int pageSize)
    {
        string query = @"SELECT *
            FROM ""Events"" ORDER BY ""CreatedAt""
            OFFSET @Offset LIMIT @PageSize";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Offset", offset);
        dynamicParameters.Add("@PageSize", pageSize);
        var response = await _dbConnection.QueryAsync<EventyResponse>(query, dynamicParameters);
        return response.ToList();
    }

    public async Task<int> GetTotalRowCountAsync()
    {
        string query = @"SELECT Count(*) FROM ""Events"" ";
        int totalRowCount = await _dbConnection.ExecuteScalarAsync<int>(query);
        return totalRowCount;
    }
}
