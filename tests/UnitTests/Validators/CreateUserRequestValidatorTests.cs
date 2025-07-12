using API.Models.Requests;
using API.Validators;
using FluentValidation.TestHelper;

namespace UnitTests.Validators;

public class CreateUserRequestValidatorTests
{
    private readonly CreateUserRequestValidator _validator;

    public CreateUserRequestValidatorTests()
    {
        _validator = new CreateUserRequestValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Fields_Are_Empty()
    {
        var request = new CreateUserRequest();

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.FirstName);
        result.ShouldHaveValidationErrorFor(r => r.LastName);
        result.ShouldHaveValidationErrorFor(r => r.Email);
        result.ShouldHaveValidationErrorFor(r => r.Password);
    }
}
