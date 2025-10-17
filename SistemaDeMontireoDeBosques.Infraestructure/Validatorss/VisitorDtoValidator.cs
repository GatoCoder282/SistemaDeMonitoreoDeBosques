// Infraestructure/Validators/VisitorDtoValidator.cs
using FluentValidation;
using SistemaDeMonitoreoDeBosques.Infraestructure.DTOs;
using SistemaDeMonitoreoDeBosques.Infraestructure.Validatorss;

namespace SistemaDeMonitoreoDeBosques.Infraestructure.Validators
{
    public class VisitorDtoValidator : AbstractValidator<VisitorDto>
    {
        public VisitorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es requerido")
                .MinimumLength(2).WithMessage("El nombre es muy corto")
                .MaximumLength(120).WithMessage("El nombre es muy largo");

            RuleFor(x => x.Ci)
                .GreaterThan(0).WithMessage("El CI debe ser mayor que 0");

            RuleFor(x => x.PhoneNumber)
                .GreaterThan(0).WithMessage("El teléfono es requerido")
                .Must(n => n.ToString().Length is >= 7 and <= 12)
                .WithMessage("El teléfono debe tener entre 7 y 12 dígitos");

            RuleFor(x => x.EmergencyNumber)
                .GreaterThan(0).WithMessage("El teléfono de emergencia es requerido")
                .Must(n => n.ToString().Length is >= 7 and <= 12)
                .WithMessage("El teléfono de emergencia debe tener entre 7 y 12 dígitos");

            RuleFor(x => x.EntryDate)
                .NotEmpty().WithMessage("La fecha de entrada es requerida");

            RuleFor(x => x.ExitDate)
                .NotEmpty().WithMessage("La fecha de salida es requerida")
                .Must((dto, exit) => exit >= dto.EntryDate)
                .WithMessage("La fecha de salida no puede ser menor a la de entrada");

            When(x => x.HasVehicle, () =>
            {
                RuleFor(x => x)
                    .Must(dto => dto.VehicleId.HasValue || dto.Vehicle != null)
                    .WithMessage("Marcaste HasVehicle pero no enviaste VehicleId ni objeto Vehicle");

                When(x => x.Vehicle != null, () =>
                {
                    RuleFor(x => x.Vehicle!).SetValidator(new VehicleDtoValidator());
                });
            });

            When(x => !x.HasVehicle, () =>
            {
                RuleFor(x => x.VehicleId)
                    .Must(v => v == null)
                    .WithMessage("No debes enviar VehicleId si HasVehicle es falso");

                RuleFor(x => x.Vehicle)
                    .Must(v => v == null)
                    .WithMessage("No debes enviar Vehicle si HasVehicle es falso");
            });
        }
    }
}
