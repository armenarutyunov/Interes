using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interes.Models
{
    public class SignUpData
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^([\s]){0,2}[A-za-z]{0,20}([\s]{0,5})([A-za-z]){0,20}([\s]){0,2}$", ErrorMessage = "Name is not valid")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^([\s]){0,2}[A-za-z]{0,20}([\s]{0,5})([A-za-z]){0,20}([\s]){0,2}$", ErrorMessage = "Name is not valid")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^[ ]{0,1}[\+]{0,1}[1]{0,1}[\.\- ]{0,1}[\(]{0,1}[0-9]{3}[\)]{0,1}[\.\- ]{0,1}[0-9]{3}[\.\- ]{0,1}[0-9]{2}[\.\- ]{0,1}[0-9]{2}[ ]{0,1}$", ErrorMessage = "Phone number is not valid")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,50})$", ErrorMessage = "Password is not valid")]
        public string Password { get; set; }

    }
}
