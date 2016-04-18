using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AResx = MVCMultiLayer.Localization.Code.Attributes;

namespace MVCMultiLayer.Business.Attributes
{
    public enum Comparison
    {
        IsEqualTo,
        IsNotEqualTo,
        IsEmptyOrNull,
        IsNotEmptyOrNull,
        IsTrue,
        IsFalse
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        public string OtherProperty { get; private set; }
        public Comparison Comparison { get; private set; }
        public object Value { get; private set; }

        public RequiredIfAttribute(string otherProperty, Comparison comparison, object value = null)
        {
            if (string.IsNullOrEmpty(otherProperty))
                throw new ArgumentNullException(nameof(otherProperty));

            OtherProperty = otherProperty;
            Comparison = comparison;
            Value = value;

            ErrorMessage = AResx.RequiredField;
        }

        private bool Validate(object actualPropertyValue)
        {
            //works on the opposite
            switch (Comparison)
            {
                case Attributes.Comparison.IsEqualTo:
                    return actualPropertyValue != null && actualPropertyValue.Equals(Value);
                case Comparison.IsNotEqualTo:
                    return actualPropertyValue == null || !actualPropertyValue.Equals(Value);                
                case Attributes.Comparison.IsEmptyOrNull:
                    return actualPropertyValue != null && !actualPropertyValue.Equals("");                    
                case Attributes.Comparison.IsNotEmptyOrNull:
                    return actualPropertyValue == null || actualPropertyValue.Equals("");
                case Attributes.Comparison.IsTrue:
                    return actualPropertyValue.Equals(false);
                case Attributes.Comparison.IsFalse:
                    return actualPropertyValue.Equals(true);
                default:
                    return false;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                var property = validationContext.ObjectInstance.GetType()
                                .GetProperty(OtherProperty);

                var propertyValue = property.GetValue(validationContext.ObjectInstance, null);

                if (!Validate(propertyValue))
                    return new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            => new[] 
                {
                    new ModelClientValidationRequiredIfRule(string.Format(ErrorMessageString, metadata.GetDisplayName()), OtherProperty, Comparison, Value)
                };        
    }

    public class ModelClientValidationRequiredIfRule : ModelClientValidationRule
    {
        public ModelClientValidationRequiredIfRule(string errorMessage, string otherProperty, Comparison comparison, object value)
        {
            ErrorMessage = errorMessage;
            ValidationType = "requiredif";
            ValidationParameters.Add("other", otherProperty);
            ValidationParameters.Add("comp", comparison.ToString().ToLower());

            if (value != null)
                ValidationParameters.Add("value", value.ToString().ToLower());
        }
    }
}