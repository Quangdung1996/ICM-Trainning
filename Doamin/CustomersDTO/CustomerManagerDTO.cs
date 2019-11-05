using commercetools.Sdk.Domain;
using commercetools.Sdk.Domain.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Doamin.CustomersDTO
{
    public class CustomerManagerDTO 
    {
        [Required]
        public string Action { get; set; }

        [RequiredIf("Action","addAddress")]
        public Address Address { get; set; }

    }

    public class RequiredIfAttribute : ValidationAttribute
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        public string _action { get; set; }
        public string _address { get; set; }

        public RequiredIfAttribute(string action, string address)
        {
            this._action = action;
            this._address = address;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectType.GetProperty(_action);
            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);

                if ((dependentValue == null && _address == null) || (dependentValue.Equals(_address)))
                {
                    if (!_innerAttribute.IsValid(value))
                    {
                        string name = validationContext.DisplayName;
                        return new ValidationResult(ErrorMessage = name + " Is required.");
                    }
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(_address));
            }
        }
    }
}
