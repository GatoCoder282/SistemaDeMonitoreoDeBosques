using FluentValidation;
using SistemaDeMonitoreoDeBosques.Core.CustomEntities;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Validatorss
{
    public class GetByIdRequestValidator : AbstractValidator<GetByIdRequest>
    {
        public GetByIdRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El id es requerido")
                .GreaterThan(0).WithMessage("El id debe ser mayor a 0")
                .LessThanOrEqualTo(1_000_000).WithMessage("El id no puede ser mayor a 1,000,000");
        }
    }
}
