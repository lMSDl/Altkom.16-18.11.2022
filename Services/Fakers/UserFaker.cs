using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Fakers
{
    public class UserFaker : BaseFaker<User>
    {
        public UserFaker()
        {
            RuleFor(x => x.Name, x => x.Internet.UserName());
            RuleFor(x => x.Password, x => x.Internet.Password());
        }
    }
}
