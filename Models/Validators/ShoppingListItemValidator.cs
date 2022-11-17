using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    public class ShoppingListItemValidator : AbstractValidator<ShoppingListItem>
    {
        public ShoppingListItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(5, 15)/*.WithMessage(x => "nazwa musi mieć od 5 do 15 znaków")*/.Must(x => x.EndsWith(".")).WithMessage(x => "Nazwa musi kończyć się kropką")
                .WithName("Nazwa");
        }
    }
}
