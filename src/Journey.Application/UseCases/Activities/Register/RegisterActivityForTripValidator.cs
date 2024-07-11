using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Activities.Register
{
    public class RegisterActivityForTripValidator : AbstractValidator<RequestRegisterActivityJson>
    {
        public RegisterActivityForTripValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.NAME_EMPTY);
        }
    }
}
