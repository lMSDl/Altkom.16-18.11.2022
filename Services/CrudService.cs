using Models;
using Services.Fakers;
using Services.Interfaces;

namespace Services
{
    public class CrudService<T> : ICrudService<T> where T : Entity
    {
        protected ICollection<T> _entities;

        public CrudService(BaseFaker<T> faker)
        {
            _entities = faker.Generate(10);
        }

        public Task<T> CreateAsync(T entity)
        {
            entity.Id = _entities.Max(x => x.Id) + 1;
            _entities.Add(entity);
            return Task.FromResult(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await ReadAsync(id);
            if(entity != null)
                _entities.Remove(entity);
        }

        public Task<T?> ReadAsync(int id)
        {
            var shoppingList = _entities.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(shoppingList);
        }

        public Task<IEnumerable<T>> ReadAsync()
        {
            return Task.FromResult(_entities.ToList().AsEnumerable());
        }

        public async Task UpdateAsync(int id, T entity)
        {
            await DeleteAsync(id);
            entity.Id = id;
            _entities.Add(entity);
        }
    }
}