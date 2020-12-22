using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product.Attirbutes.ValidationAttributes
{
    public class TodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                DateTime date = new DateTime(((DateTime)value).Year, ((DateTime)value).Month, ((DateTime)value).Day);
                if(date == DateTime.Today)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Entry date must be today.");
                }
            }
            catch(Exception ex)
            {
                return new ValidationResult(ex.Message);
            }
        }
    }
}