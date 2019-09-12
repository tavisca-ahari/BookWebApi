using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookWebApi.Model;
using System.Text.RegularExpressions;
using BookWebApi.Util;

namespace BookWebApi.Service
{
    public class BookValidator : AbstractValidator<Book>
    {

        public BookValidator()
        {
            RuleFor(book => book.Id)
                .NotEmpty()
                .WithMessage("Id should not be empty.")
                .GreaterThan(0)
                .WithMessage("Id should be positive");

            RuleFor(book => book.Price)
                .NotEmpty()
                .WithMessage("Price should not be empty.")
                .GreaterThan(0)
                .WithMessage("Price should be positive");

            RuleFor(book => book.Name)
                .NotNull()
                .WithMessage("Name should not be empty.")
                .Must(StringUtil.HasOnlyAlphabets)
                .WithMessage("Name should contain only alphabets.");

            RuleFor(book => book.Author)
                .NotNull()
                .WithMessage("Author should not be empty.")
                .Must(StringUtil.HasOnlyAlphabets)
                .WithMessage("Author should contain only alphabets.");

            RuleFor(book => book.Category)
                .NotNull()
                .WithMessage("Category should not be empty.")
                .Must(StringUtil.HasOnlyAlphabets)
                .WithMessage("Category should contain only alphabets.");
        }

    }
}
