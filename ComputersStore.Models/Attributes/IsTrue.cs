using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsTrue : ValidationAttribute
    {
        public string ValidationFailMessage { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = (bool)value;
            if (property)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ValidationFailMessage);
        }
    }
}
