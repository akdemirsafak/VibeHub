namespace VibePass.Core.Repository;

public interface IGenericRepository<TEntity, TResponse>
    where TEntity : class
    where TResponse : class
{
    Task<TResponse> GetByIdAsync(string id);
    Task<List<TResponse>> GetAllAsync();
    Task<List<TResponse>> GetListAsync(int offset, int pageSize);
    Task<int> GetTotalRowCountAsync();
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(string id, TEntity entity);
    Task<int> DeleteByIdAsync(string id);

}
