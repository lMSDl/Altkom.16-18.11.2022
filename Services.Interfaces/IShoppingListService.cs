using Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IShoppingListService
    {
        Task<ShoppingList?> ReadAsync(int id);
        Task<IEnumerable<ShoppingList>> ReadAsync();
    }
}