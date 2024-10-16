using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Entities;
using VibePass.Core.Models.Eventy;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class EventyRepository : BaseRepository, IEventyRepository
{
    public EventyRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task CreateAsync(Eventy entity)
    {
        var command = @"INSERT INTO Events (Id, Title, Description, StartDate, EndDate, Location, ImageUrl, CreatedAt) 
            VALUES (@Id, @Title, @Description, @StartDate, @EndDate, @Location,@ImageUrl, @CreatedAt) RETURNING *";
        DynamicParameters queryParameters = new DynamicParameters();
        queryParameters.Add("Id", entity.Id);
        queryParameters.Add("Title", entity.Title);
        queryParameters.Add("Description", entity.Description);
        queryParameters.Add("StartDate", entity.StartDate);
        queryParameters.Add("EndDate", entity.EndDate);
        queryParameters.Add("Location", entity.Location);
        queryParameters.Add("ImageUrl", entity.ImageUrl);
        queryParameters.Add("CreatedAt", DateTime.UtcNow);

        var record = await _dbConnection.ExecuteAsync(command, queryParameters);
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        //DELETE FROM Events WHERE Id = @Id RETURNING *


        DynamicParameters queryParameters = new DynamicParameters();
        queryParameters.Add("Id", id);

        var record = await _dbConnection.QueryFirstOrDefaultAsync<EventyResponse>("Select * from Events Where Id=@Id");

        queryParameters.Add("IsDeleted", true);
        queryParameters.Add("DeletedAt", DateTime.UtcNow);


        var query = @"UPDATE Events SET IsDeleted = @IsDeleted,DeletedAt=@DeletedAt WHERE Id = @Id";
        var affectedRowCount = await _dbConnection.ExecuteAsync(query, queryParameters);
        return affectedRowCount;

    }
    public async Task UpdateAsync(string id, Eventy entity)
    {

        DynamicParameters queryParameters = new DynamicParameters();
        queryParameters.Add("Id", id);

        var record = await _dbConnection.QueryFirstOrDefaultAsync<Eventy>("Select * from Events Where Id=@Id");


        queryParameters.Add("Title", entity.Title);
        queryParameters.Add("Description", entity.Description);
        queryParameters.Add("StartDate", entity.StartDate, dbType: System.Data.DbType.DateTime);
        queryParameters.Add("EndDate", entity.EndDate, System.Data.DbType.DateTime);
        queryParameters.Add("Location", entity.Location);
        queryParameters.Add("ImageUrl", entity.ImageUrl);
        queryParameters.Add("UpdatedAt", DateTime.UtcNow);
        var command = @"UPDATE Events SET Title = @Title, 
                        Description = @Description, 
                        StartDate = @StartDate, 
                        EndDate = @EndDate, 
                        Location = @Location, 
                        ImageUrl = @ImageUrl, 
                        UpdatedAt = @UpdatedAt 
                        WHERE Id = @Id";
        var affectedRowCount = await _dbConnection.ExecuteAsync(command, queryParameters);
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
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);
        var record = await _dbConnection.QueryFirstOrDefaultAsync<EventyResponse>(query, dynamicParameters);
        return record;
    }

    public async Task<List<EventyResponse>> GetListAsync(int offset, int pageSize)
    {
        string query = @"SELECT *
            FROM Events ORDER BY CreatedAt
            OFFSET @Offset LIMIT @PageSize";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Offset", offset);
        dynamicParameters.Add("PageSize", pageSize);
        var response = await _dbConnection.QueryAsync<EventyResponse>(query, dynamicParameters);
        return response.ToList();
    }

    public async Task<int> GetTotalRowCountAsync()
    {
        string query = @"SELECT Count(*) FROM Events ";
        int totalRowCount = await _dbConnection.ExecuteScalarAsync<int>(query);
        return totalRowCount;
    }
}
