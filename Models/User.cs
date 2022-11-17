using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : Entity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = "";
        [MinLength(8)]
        [MyAnnotation]
        public string Password { get; set; } = "";
        [EmailAddress(ErrorMessage = "błędny email")]
        public string? Email { get; set; }
    }
}
