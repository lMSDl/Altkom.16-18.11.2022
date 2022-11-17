using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Parent
    {
        public string? Name { get; set; }

        public DateOnly DateTime { get; set; }

        public IEnumerable<Child>? Children { get; set; }

        public string ClassName => nameof(Parent);
    }
}
