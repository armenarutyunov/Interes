using System;
using System.ComponentModel.DataAnnotations;


namespace Interes.Validations
{
    public class DateRangeAttribute: RangeAttribute
    {
        public DateRangeAttribute(string maximumDate):base(typeof(DateTime), DateTime.Now.AddDays(1).ToShortDateString(), maximumDate)
        {

        }
    }
}