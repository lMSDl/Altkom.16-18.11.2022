using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Fakers
{
    public class ShoppingListFaker : BaseFaker<ShoppingList>
    {
        public ShoppingListFaker()
        {
            RuleFor(x => x.Name, x => x.Name.Random.String2(15));
        }
    }
}
