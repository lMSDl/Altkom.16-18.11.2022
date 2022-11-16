using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IShoppingListItemsService : ICrudService<ShoppingListItem>
    {
        Task<IEnumerable<ShoppingListItem>> ReadFromParentAsync(int parentId);
    }
}
