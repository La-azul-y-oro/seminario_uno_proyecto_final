namespace api.Services.Interfaces
{
    public interface IGenericService<TEntity, TKey>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        void Create(TEntity entity);
        void Update(TKey id, TEntity entity);
        void Delete(TKey id);
    }
}
