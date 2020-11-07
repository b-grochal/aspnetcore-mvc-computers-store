using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfTrue : RequiredAttribute
    {
        private readonly string propertyName;
        public RequiredIfTrue(string propertyName)
        {
            this.propertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();

            bool.TryParse(type.GetProperty(propertyName).GetValue(instance)?.ToString(), out bool propertyValue);

            var file = value as IFormFile;

            if (propertyValue && file == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
