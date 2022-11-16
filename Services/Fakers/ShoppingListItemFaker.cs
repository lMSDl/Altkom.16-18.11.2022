using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Fakers
{
    public class ShoppingListItemFaker : BaseFaker<ShoppingListItem>
    {
        public ShoppingListItemFaker()
        {
            RuleFor(x => x.Name, x => x.Commerce.ProductName());
            RuleFor(x => x.ShoppingListId, x => x.Random.Int(1, 5));
        }
    }
}
