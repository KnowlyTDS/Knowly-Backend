namespace KnowlyApp.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);

        Task DeleteAsync(Entity entity);

        Task<List<Entity>> GetAllViewModel();

        Task<List<Entity>> GetAllWithIncludes(List<string> properties);

        Task<Entity> GetViewModelById(int id);

        Task UpdateAsync(Entity entity, int id);

        Task<Entity>GetByIdWithIncludesAsync (int id, List<string> properties);
    }
}