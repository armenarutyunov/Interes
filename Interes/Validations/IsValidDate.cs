using System;
using System.ComponentModel.DataAnnotations;

namespace Interes.Validations
{
    public class IsValidDateAttribute :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime datetime = Convert.ToDateTime(value);

            return datetime >= DateTime.Now.AddDays(1);
        }
      
    }
}