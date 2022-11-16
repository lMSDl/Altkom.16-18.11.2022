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

        public Task<ShoppingList?> ReadAsync(int id)
        {
            var shoppingList = _entities.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(shoppingList);
        }

        public Task<IEnumerable<ShoppingList>> ReadAsync()
        {
            return Task.FromResult(_entities.ToList().AsEnumerable());
        }
    }
}