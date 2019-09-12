using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Validator
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(id => id)
                .NotEmpty()
                .WithMessage("Id in URL should not be empty.")
                .GreaterThan(0)
                .WithMessage("Id in URL should be positive");
        }
    }
}
