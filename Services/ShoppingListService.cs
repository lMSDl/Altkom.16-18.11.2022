using Models;
using Services.Fakers;
using Services.Interfaces;

namespace Services
{
    public class ShoppingListService : IShoppingListService
    {
        private ICollection<ShoppingList> _entities;

        public ShoppingListService(ShoppingListFaker shoppingListFaker)
        {
            _entities = shoppingListFaker.Generate(10);
        }

        public Task<ShoppingList> CreateAsync(ShoppingList entity)
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

        public Task<ShoppingList?> ReadAsync(int id)
        {
            var shoppingList = _entities.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(shoppingList);
        }

        public Task<IEnumerable<ShoppingList>> ReadAsync()
        {
            return Task.FromResult(_entities.ToList().AsEnumerable());
        }

        public async Task UpdateAsync(int id, ShoppingList entity)
        {
            await DeleteAsync(id);
            entity.Id = id;
            _entities.Add(entity);
        }
    }
}