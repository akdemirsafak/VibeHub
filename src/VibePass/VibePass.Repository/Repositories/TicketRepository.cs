using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Models;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class TicketRepository : BaseRepository, ITicketRepository
{
    public TicketRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<List<TicketResponse>> GetAllAsync()
    {

        var query = "SELECT * FROM Tickets";
        var records = await _dbConnection.QueryAsync<TicketResponse>(query);
        return records.ToList();

    }

    public Task<TicketResponse> GetByIdAsync(string id)
    {
        var query = "SELECT * FROM Tickets WHERE Id = @Id";
        var record = _dbConnection.QueryFirstOrDefaultAsync<TicketResponse>(query, id);
        return record;

    }

    public async Task<List<TicketResponse>> GetListAsync(int offset, int pageSize)
    {
        string query = @"SELECT *
            FROM ""Tickets"" ORDER BY ""CreatedAt""
            OFFSET @Offset LIMIT @PageSize";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Offset", offset);
        dynamicParameters.Add("@PageSize", pageSize);
        var response = await _dbConnection.QueryAsync<TicketResponse>(query, dynamicParameters);
        return response.ToList();
    }

    public async Task<int> GetTotalRowCountAsync()
    {
        string query = @"SELECT Count(*) FROM ""Tickets"" ";
        int totalRowCount = await _dbConnection.ExecuteScalarAsync<int>(query);
        return totalRowCount;
    }
}
