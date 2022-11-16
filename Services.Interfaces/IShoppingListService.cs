using Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IShoppingListService
    {
        Task<ShoppingList> CreateAsync(ShoppingList entity);
        Task<ShoppingList?> ReadAsync(int id);
        Task<IEnumerable<ShoppingList>> ReadAsync();
        Task UpdateAsync(int id, ShoppingList entity);
        Task DeleteAsync(int id);
    }
}