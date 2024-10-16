using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Entities;
using VibePass.Core.Models.Performer;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class PerformerRepository : BaseRepository, IPerformerRepository
{
    public PerformerRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task CreateAsync(Performer entity)
    {
        string command = @"INSERT INTO Performers 
                            (Id, Name, LastName, About, BirthDate, CreatedAt) 
                            VALUES (@Id, @Name, @LastName, @About, @BirthDate, @CreatedAt) RETURNING *";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", entity.Id);
        dynamicParameters.Add("Name", entity.Name);
        dynamicParameters.Add("LastName", entity.LastName);
        dynamicParameters.Add("About", entity.About);
        dynamicParameters.Add("BirthDate", entity.BirthDate);
        dynamicParameters.Add("CreatedAt", DateTime.UtcNow);

        await _dbConnection.ExecuteAsync(command, dynamicParameters);

    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        string query = @"Select * from Performers Where Id=@Id";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);

        Performer performer = await _dbConnection.QuerySingleOrDefaultAsync<Performer>(query,dynamicParameters);
        if (performer is null)
            throw new Exception("Performer not found.");

        string command = $@"Update Performers Set IsDeleted=true,DeletedAt=@DeletedAt Where Id=@Id";
        dynamicParameters.Add("DeletedAt", DateTime.UtcNow);
        return await _dbConnection.ExecuteAsync(command, dynamicParameters);
    }

    public async Task<List<PerformerResponse>> GetAllAsync()
    {
        string query = "SELECT * FROM Performers";
        var records = await _dbConnection.QueryAsync<PerformerResponse>(query);
        return records.ToList();
    }

    public async Task<PerformerResponse> GetByIdAsync(string id)
    {
        string query = "SELECT * FROM Performers WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<PerformerResponse>(query, new { Id = id });

    }

    public async Task<List<PerformerResponse>> GetListAsync(int offset, int pageSize)
    {
        string query= "SELECT * FROM Performers OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";//ORDER BY CreatedAt

        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Offset", offset);
        dynamicParameters.Add("PageSize", pageSize);
        var response = await _dbConnection.QueryAsync<PerformerResponse>(query, dynamicParameters);
        return response.ToList();
    }

    public async Task<int> GetTotalRowCountAsync()
    {
        string query = @"SELECT Count(*) FROM Performers";
        return await _dbConnection.ExecuteScalarAsync<int>(query);
    }

    public async Task UpdateAsync(string id, Performer entity)
    {
        string query = @"Select * from Performers where Id=@Id";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);
        Performer performer = await _dbConnection.QuerySingleOrDefaultAsync<Performer>(query, dynamicParameters);
        if (performer is null)
            throw new Exception("Performer not found.");

        string command = @"Update Performers Set Name=@Name, LastName=@LastName, About=@About, BirthDate=@BirthDate Where Id=@Id";
        
        dynamicParameters.Add("Name", entity.Name);
        dynamicParameters.Add("LastName", entity.LastName);
        dynamicParameters.Add("About", entity.About);
        dynamicParameters.Add("BirthDate", entity.BirthDate);
        await _dbConnection.ExecuteAsync(command, dynamicParameters);
    }
}
