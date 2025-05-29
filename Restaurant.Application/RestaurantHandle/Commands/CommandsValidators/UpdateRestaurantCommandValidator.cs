using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace RestaurantsApp.Application.RestaurantHandle.Commands.CommandsValidators
{
    internal class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required")
           .MinimumLength(3).WithMessage("Name must be more than 3 characters")
           .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required")
                .MaximumLength(50).WithMessage("Type must not exceed 50 characters");

            RuleFor(x => x.ContactEmail)
                .EmailAddress().WithMessage("A valid email address is required")
                .When(x => !string.IsNullOrEmpty(x.ContactEmail));

            RuleFor(x => x.ContactNumber)
                .Matches(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$")
                .WithMessage("A valid phone number is required")
                .When(x => !string.IsNullOrEmpty(x.ContactNumber));

            RuleFor(x => x.Street)
                .MaximumLength(100).WithMessage("Street must not exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.Street));

            RuleFor(x => x.City)
                .MaximumLength(50).WithMessage("City must not exceed 50 characters")
                .When(x => !string.IsNullOrEmpty(x.City));

            RuleFor(x => x.PostalCode)
                .MaximumLength(20).WithMessage("Postal code must not exceed 20 characters")
                .When(x => !string.IsNullOrEmpty(x.PostalCode));

            RuleFor(x => x.Country)
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters")
                .When(x => !string.IsNullOrEmpty(x.Country));
        }
    
    }
}
