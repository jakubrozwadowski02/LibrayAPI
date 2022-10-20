using FluentValidation;
using FluentValidation.Validators;
using LibrayAPI.Data;
using LibrayAPI.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibrayAPI.Dtos.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly ApplicationDbContext _context;

        public RegisterUserDtoValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .Matches(new Regex("^[0-9]{9}$")).WithMessage("PhoneNumber not valid");


            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password).WithMessage("The passwords provided do not match");

            RuleFor(x => x.Email)
                .Custom((value, contextValidator) =>
                {
                    var emailInUse = _context.Users.Any(u => u.Email == value);

                    if (emailInUse)
                    {
                        contextValidator.AddFailure("Email", "That Email is taken");
                    }
                });
        }
    }
}
