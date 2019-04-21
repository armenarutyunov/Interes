
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Interes.Models
{
    public class OrderDetails : IValidatableObject
    {
        public static bool isInValid;
        public static bool isInValidTime;

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date), Display(Name = "Date")]
        //[DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode =true)]
       // [DateRange("01/01/2020", ErrorMessage ="It cannot be earlier than tommorow")]
        //[IsValidDate]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.Time), Display(Name = "Time")]
        public DateTime DeliveryTime { get; set; }
        [Display(Name = "Street")]
        [Required(ErrorMessage = "Street is required")]
        public string StreetAddress { get; set; }

        public string UnitApt { get; set; }

        //[Required]
        //public string HomeNumber { get; set; }

       

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^([\s]){0,2}[A-za-z]{0,20}([\s]{0,5})([A-za-z]){0,20}([\s]){0,2}$", ErrorMessage ="City is not valid")]
        public string City { get; set; }

        //[DataType(DataType.PostalCode), Display(Name = "Postal Code")]
        [Required(ErrorMessage ="Postal code is required" )]
        [RegularExpression(@"^[a-zA-Z]\d{1}[a-zA-Z](\-| |)\d{1}[a-zA-Z]\d{1}$", ErrorMessage ="Postal code is not valid")]
        public string PostalCode { get; set; }
      
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^([\s]){0,2}[A-za-z]{0,20}([\s]{0,5})([A-za-z]){0,20}([\s]){0,2}$", ErrorMessage ="Name is not valid")]
        //[IsNameValid]
        public string Name { get; set; }
         
        //[DataType(DataType.PhoneNumber), Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required")]
        //[RegularExpression(@"^[\(\)\.\- ]{0,}[0-9]{3}[\(\)\.\- ]{0,}[0-9]{3}[\(\)\.\- ]{0,}[0-9]{2}[\(\)\.\- ]{0,}[0-9]{2}[\(\)\.\- ]{0,}$" /*@"^([0 - 9\(\)\/\+ \-]*)$"*/ /*@"^[0 - 9]{9, 12}$"*/, ErrorMessage ="Phone number is not valid")]
        [RegularExpression(@"^[ ]{0,1}[\+]{0,1}[1]{0,1}[\.\- ]{0,1}[\(]{0,1}[0-9]{3}[\)]{0,1}[\.\- ]{0,1}[0-9]{3}[\.\- ]{0,1}[0-9]{2}[\.\- ]{0,1}[0-9]{2}[ ]{0,1}$", ErrorMessage = "Phone number is not valid")]
        public string Phone { get; set; }

        //[/*DataType(DataType.EmailAddress),*/ Display(Name = "Email")]
        //[EmailAddress(ErrorMessage = "Email address is not valid")]
        //[Remote("IsValidEmail", "Checkout", ErrorMessage = "Not a valid e-mail!")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }

        public List<string> Addresses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            isInValid = false;
            isInValidTime = false;

            DateTime d = DeliveryDate;
            DateTime t = DeliveryTime;
            DateTime orderDateTime = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
            TimeSpan a = orderDateTime.Subtract(DateTime.Now);

            if (a.Days * 24 * 60 + a.Hours * 60 + a.Minutes < 36 * 60)
            {
                isInValid = true; isInValidTime = true;
                yield return new ValidationResult("You need to correct Delivery Date/Time options"/*, date*/);
            }

            var name = new[] { "Name" };
            if (Name.Length > 40)
            {
                isInValid = true;
                yield return new ValidationResult("Name cannot contain more than 40 characters", name);
            }
        }
    }
}