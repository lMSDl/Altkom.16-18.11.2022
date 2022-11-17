using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyAnnotation : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            return (value as string)?.Contains('.') ?? true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"wartość {name} powinna zawierać kropkę";
        }
    }
}
