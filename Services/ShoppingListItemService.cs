using Models;
using Services.Fakers;
using Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Services
{
    public class ShoppingListItemService : CrudService<ShoppingListItem>, IShoppingListItemsService
    {
        public ShoppingListItemService(ShoppingListItemFaker faker) : base(faker)
        {
        }

        public Task<IEnumerable<ShoppingListItem>> ReadFromParentAsync(int parentId)
        {
            return Task.FromResult(_entities.Where(x => x.ShoppingListId == parentId).ToList().AsEnumerable());
        }
    }
}