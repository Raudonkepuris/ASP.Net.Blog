using System.ComponentModel.DataAnnotations;
using Blog.Interfaces;

namespace Blog.Validation
{
    public class IsApprovedEmail : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Provided email is not included in approved emails list";


        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            IApprovedEmailsDependancy? service = validationContext.GetService(typeof(IApprovedEmailsDependancy)) as IApprovedEmailsDependancy;
            bool isapproved = service.IsEmailApproved(value.ToString()).Result;

            if (isapproved == false)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
