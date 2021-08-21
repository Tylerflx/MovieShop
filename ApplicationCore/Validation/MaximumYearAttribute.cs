using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Validation
{
    public class MaximumYearAttribute : ValidationAttribute
    {
        public int Year { get;}
        public MaximumYearAttribute(int year)
        {
            //is the one we want year to be max
            Year = year;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //year user entered
            var year = ((DateTime?) value)?.Year;
            if (year < Year)
            {
                return new ValidationResult($"Year should not be less than {Year}");
            }
            return ValidationResult.Success;
        }
    }
}
