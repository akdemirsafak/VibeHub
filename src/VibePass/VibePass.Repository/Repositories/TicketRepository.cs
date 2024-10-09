using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Entities;
using VibePass.Core.Models.Ticket;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class TicketRepository : BaseRepository, ITicketRepository
{
    public TicketRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task CreateAsync(Ticket entity)
    {
        string command = @"INSERT INTO Tickets 
                        (Name, Description, Price, Quantity, EventyId, CreatedAt) 
                        VALUES (@Name, @Description, @Price, @Quantity, @EventyId, @CreatedAt) 
                        RETURNING *";
        DynamicParameters queryParameters = new DynamicParameters();
        queryParameters.Add("Name", entity.Name);
        queryParameters.Add("Description", entity.Description);
        queryParameters.Add("Price", entity.Price);
        queryParameters.Add("Quantity", entity.Quantity);
        queryParameters.Add("EventyId", entity.EventyId);
        queryParameters.Add("CreatedAt", DateTime.UtcNow);

        await _dbConnection.ExecuteAsync(command, queryParameters);
    }

    public Task<int> DeleteByIdAsync(string id)
    {
        string query = @"SELECT Count(*) FROM Tickets WHERE Id=@Id";
        int count = _dbConnection.ExecuteScalar<int>(query, id);
        if (count != 0)
            throw new ArgumentNullException("Ticket not found");

        string command = @"DELETE FROM Tickets WHERE Id=@Id";
        return _dbConnection.ExecuteAsync(command, id);
    }

    public async Task<List<TicketResponse>> GetAllAsync()
    {

        var query = "SELECT * FROM Tickets";
        var records = await _dbConnection.QueryAsync<TicketResponse>(query);
        return records.ToList();

    }

    public async Task<TicketResponse> GetByIdAsync(string id)
    {
        var query = "SELECT * FROM Tickets WHERE Id = @Id";
        var record = await _dbConnection.QueryFirstOrDefaultAsync<TicketResponse>(query, id);
        return record;

    }

    public async Task<List<TicketResponse>> GetListAsync(int offset, int pageSize)
    {
        string query = @"SELECT *
                FROM Tickets ORDER BY CreatedAt
                OFFSET @Offset LIMIT @PageSize";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Offset", offset);
        dynamicParameters.Add("@PageSize", pageSize);
        var response = await _dbConnection.QueryAsync<TicketResponse>(query, dynamicParameters);
        return response.ToList();
    }

    public async Task<int> GetTotalRowCountAsync()
    {
        string query = @"SELECT Count(*) FROM Tickets";
        int totalRowCount = await _dbConnection.ExecuteScalarAsync<int>(query);
        return totalRowCount;
    }

    public async Task UpdateAsync(string id, Ticket entity)
    {
        string query = @"SELECT Count(*) FROM Tickets WHERE Id=@Id";
        int count = _dbConnection.ExecuteScalar<int>(query, id);
        if (count != 0)
            throw new ArgumentNullException("Ticket not found");

        string command = @"UPDATE Tickets SET 
                    Name=@Name, 
                    Description=@Description, 
                    Price=@Price, 
                    Quantity=@Quantity,
                    UpdatedAt=@UpdatedAt 
                    WHERE Id=@Id";
        DynamicParameters queryParameters = new DynamicParameters();
        queryParameters.Add("Id", id);
        queryParameters.Add("Name", entity.Name);
        queryParameters.Add("Description", entity.Description);
        queryParameters.Add("Price", entity.Price);
        queryParameters.Add("Quantity", entity.Quantity);
        queryParameters.Add("EventyId", entity.EventyId);
        queryParameters.Add("UpdatedAt", DateTime.UtcNow);

        await _dbConnection.ExecuteAsync(command, queryParameters);
    }
}
