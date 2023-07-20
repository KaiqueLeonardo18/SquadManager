using FluentValidation;
using SquadManager.Models;

namespace SquadManager.Validator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            //RuleFor(user => user.Email).EmailAddress().NotNull().WithMessage("Email vazio");
            //RuleFor(user => user.Password).NotNull().WithMessage("Digite uma senha");
        }
    }
}
