using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Models;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var query = @"Select * from ""Categories""";
        var categories = await _dbConnection.QueryAsync<CategoryResponse>(query);
        return categories.ToList();
    }

    public async Task<CategoryResponse> GetByIdAsync(string id)
    {
        var query = $"Select * from \"Categories\" where \"Id\"=@id";
        var category = await _dbConnection.QuerySingleOrDefaultAsync<CategoryResponse>(query, id);
        return category;
    }

    public async Task<List<CategoryResponse>> GetListAsync(int offset, int pageSize)
    {
        string query = @"SELECT *
            FROM ""Categories"" ORDER BY ""CreatedAt""
            OFFSET @Offset LIMIT @PageSize";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Offset", offset);
        dynamicParameters.Add("@PageSize", pageSize);
        var response = await _dbConnection.QueryAsync<CategoryResponse>(query, dynamicParameters);
        return response.ToList();
    }

    public async Task<int> GetTotalRowCountAsync()
    {
        string query = @"SELECT Count(*) FROM ""Categories"" ";
        int totalRowCount = await _dbConnection.ExecuteScalarAsync<int>(query);
        return totalRowCount;
    }
}
