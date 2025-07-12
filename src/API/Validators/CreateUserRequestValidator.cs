using API.Models.Requests;
using FluentValidation;

namespace API.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("First name is required")
            .EmailAddress().WithMessage("Email format is valid");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        RuleFor(x => x.Role)
            .Must(role => new[] { "User", "Admin" }.Contains(role))
            .WithMessage("Role must be either 'User' or 'Admin'");
    }
}
