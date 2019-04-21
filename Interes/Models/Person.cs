using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Interes.Models
{



    public class Person : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-za-z]{0,20}([\s]{0,5})([A-za-z]){0,20}([\s]){0,5}$", ErrorMessage = "Name is not valid")]
        //[Remote("IsValid", "Person", ErrorMessage = "Comes from Remote")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        //[Remote("Validate", "Person", ErrorMessage ="Comes from Remote")]
        public int Income { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var pIncome = new[] { "Income" };
            if (Income < 0)
            {
                yield return new ValidationResult("Income cannot be negative", pIncome);
            }
            var pName = new[] { "Name" };
            if (Name.Length > 5)
            {
                yield return new ValidationResult("Name cannot be such huge in length", pName);
            }
            var pBDate = new[] { "BirthDate" };
            if (BirthDate > DateTime.Now)
            {
                yield return new ValidationResult("Sorry Future Date cannot be accepted.", pBDate);
            }

        }
    }

}