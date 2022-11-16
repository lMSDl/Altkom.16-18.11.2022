using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers
{
    public class ShoppingListsController : CrudController<ShoppingList>
    {
        public ShoppingListsController(IShoppingListService service) : base(service)
        {
        }
    }
}
