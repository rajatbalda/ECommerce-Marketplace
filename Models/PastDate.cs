using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class PastDateAttribute : ValidationAttribute, IClientModelValidator
    {
        private int numYears;
        public PastDateAttribute(int years = -1) => numYears = years;
        protected override ValidationResult IsValid(object? value,
        ValidationContext ctx) //server-side
        {
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;
                if (numYears == -1)
                { // no limit on past date
                    if (dateToCheck < DateTime.Today)
                        return ValidationResult.Success!;
                }
                else
                {
                    DateTime minDate = DateTime.Today.AddYears(-numYears);
                    if (dateToCheck >= minDate && dateToCheck < DateTime.Today)
                        return ValidationResult.Success!;
                }
            }
            return new ValidationResult(GetMsg(ctx.DisplayName ?? "Value"));
        }
        public void AddValidation(ClientModelValidationContext c) //client-side
        {
            //for emitting data-val-* attributes
            if (!c.Attributes.ContainsKey("data-val"))
                c.Attributes.Add("data - val", "true");//this checkup is necessary
                                                       //pass values required for jQuery to perform validation: args and err msg
            c.Attributes.Add("data-val-pastdate-numyears", numYears.ToString());
            c.Attributes.Add("data-val-pastdate", GetMsg(
            c.ModelMetadata.DisplayName ?? c.ModelMetadata.Name ?? "Value"));
        }
        private string GetMsg(string name) =>
        base.ErrorMessage ?? name + " must be a valid past date" +
        (numYears == -1 ? "." : " (max " + numYears + " years ago).");
    }
    public class MinimumAgeAttribute : ValidationAttribute, IClientModelValidator
    {
        private int minYears;
        public MinimumAgeAttribute(int years)
        {
            minYears = years;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext ctx)
        {
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;
                dateToCheck = dateToCheck.AddYears(minYears);
                if (dateToCheck <= DateTime.Today)
                {
                    return ValidationResult.Success!;
                }
            }
            return new ValidationResult(GetMsg(ctx.DisplayName ?? "Date"));
        }

        public void AddValidation(ClientModelValidationContext ctx)
        {
            if (!ctx.Attributes.ContainsKey("data-val"))
                ctx.Attributes.Add("data-val", "true");
            ctx.Attributes.Add("data-val-minimumage-years",
                minYears.ToString());
            ctx.Attributes.Add("data-val-minimumage",
                GetMsg(ctx.ModelMetadata.DisplayName ?? ctx.ModelMetadata.Name ?? "Date"));
        }

        private string GetMsg(string name) =>
            base.ErrorMessage ?? $"{name} must be at least {minYears} years ago.";
    }
}
