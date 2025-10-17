// Infraestructure/Validators/VehicleDtoValidator.cs
using FluentValidation;
using SistemaDeMonitoreoDeBosques.Infraestructure.DTOs;
using System.Text.RegularExpressions;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Validatorss
{
    public class VehicleDtoValidator : AbstractValidator<VehicleDto>
    {
        public VehicleDtoValidator()
        {
            RuleFor(x => x.vehicle_type)
                .NotEmpty().WithMessage("El tipo de vehículo es requerido")
                .MaximumLength(50).WithMessage("El tipo de vehículo es muy largo");

            RuleFor(x => x.placa)
                .NotEmpty().WithMessage("La placa es requerida")
                .MaximumLength(12).WithMessage("La placa es muy larga")
                .Must(p => Regex.IsMatch(p, "^[A-Za-z0-9-]{5,12}$"))
                .WithMessage("La placa debe ser alfanumérica (5 a 12 caracteres)");

            RuleFor(x => x.modelo)
                .NotEmpty().WithMessage("El modelo es requerido")
                .MaximumLength(50).WithMessage("Modelo muy largo");

            RuleFor(x => x.marca)
                .NotEmpty().WithMessage("La marca es requerida")
                .MaximumLength(50).WithMessage("Marca muy larga");

            RuleFor(x => x.color)
                .NotEmpty().WithMessage("El color es requerido")
                .MaximumLength(30).WithMessage("Color muy largo");
        }
    }
}
