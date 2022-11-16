﻿using Bogus;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Fakers
{
    public abstract class BaseFaker<T> : Faker<T> where T : Entity
    {
        public BaseFaker() : base("pl")
        {
            RuleFor(x => x.Id, x => x.UniqueIndex + 1);
        }
    }
}
