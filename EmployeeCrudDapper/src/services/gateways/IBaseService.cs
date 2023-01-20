namespace EmployeeCrudDapper.services.gateways;

public interface IBaseService<TEntity, in TEntityId>
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(TEntityId entityId);
    Task<TEntity> Create(TEntity entity);
    Task<TEntity> Update(TEntityId entityId, TEntity entity);
    Task Delete(TEntity entity, TEntityId entityId);
    Task<IEnumerable<TEntity>> GetAllDeleted();
}