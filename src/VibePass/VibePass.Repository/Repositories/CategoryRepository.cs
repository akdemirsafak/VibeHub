using Dapper;
using Microsoft.Extensions.Configuration;
using VibePass.Core.Entities;
using VibePass.Core.Models.Category;
using VibePass.Core.Repository;

namespace VibePass.Repository.Repositories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task CreateAsync(Category entity)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", entity.Id);
        dynamicParameters.Add("Name", entity.Name);
        dynamicParameters.Add("Description", entity.Description);
        dynamicParameters.Add("CreatedAt", DateTime.UtcNow);

        string query = @"INSERT INTO Categories (Id,Name, Description, CreatedAt) VALUES (@Id, @Name, @Description, @CreatedAt)";
        await _dbConnection.ExecuteAsync(query, dynamicParameters);
    }

    public async Task<int> DeleteByIdAsync(string id)
    {
        string query = @"Select * from Categories Where Id=@Id";

        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);


        if (string.IsNullOrEmpty(query))
        {
            throw new Exception("Category not found.");
        }
        string command = $@"Delete from Categories Where Id=Id";
        Category category = await _dbConnection.QuerySingleOrDefaultAsync<Category>(query, dynamicParameters);
        if (category != null)
            return await _dbConnection.ExecuteAsync(command, id);
        return 0;
    }
    public async Task UpdateAsync(string id, Category entity)
    {
        string query = $"Select * from Categories where Id=@Id";
        DynamicParameters idParameter = new DynamicParameters();
        idParameter.Add("Id", id);
        Category category = await _dbConnection.QuerySingleOrDefaultAsync<Category>(query, idParameter);
        if (category == null)
        {
            throw new Exception("Category not found.");
        }
        string command = @"Update Categories Set Name=@Name, Description=@Description Where Id=@Id";

        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);
        dynamicParameters.Add("Name", entity.Name);
        dynamicParameters.Add("Description", entity.Description);

        await _dbConnection.ExecuteAsync(command, dynamicParameters);

    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        string query = "Select * from Categories";
        var categories = await _dbConnection.QueryAsync<CategoryResponse>(query);
        return categories.ToList();
    }

    public async Task<CategoryResponse> GetByIdAsync(string id)
    {
        //var query = $"Select * from Categories where Id='{id}'";
        string query = $"Select * from Categories where Id=@Id";
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Id", id);
        CategoryResponse category = await _dbConnection.QuerySingleOrDefaultAsync<CategoryResponse>(query, dynamicParameters);
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
        string query = @"SELECT Count(*) FROM Categories";
        int totalRowCount = await _dbConnection.ExecuteScalarAsync<int>(query);
        return totalRowCount;
    }
}
