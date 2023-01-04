using ArquitecturaAppEmpresariales.Ecommerce.Application.DTO;
using FluentValidation;

namespace ArquitecturaAppEmpresariales.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UsersDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
