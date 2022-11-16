using Models;
using Services.Fakers;
using Services.Interfaces;

namespace Services
{
    public class ShoppingListService : CrudService<ShoppingList>, IShoppingListService
    {
        public ShoppingListService(ShoppingListFaker faker) : base(faker)
        {
        }
    }
}