using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Validators;

public sealed class OperationReportConfigurationValidator : AbstractValidator<OperationReportConfigurationPageModel>
{
    public OperationReportConfigurationValidator()
    {
        RuleFor(model => model.Description)
            .MaximumLength(1024)
            .WithName("Descripción");

        RuleFor(model => model.Income)
            .GreaterThanOrEqualTo(model => model.IncomeBankDeposit + model.PeriodResult + model.CAMComission)
            .WithMessage("Los ingresos totales no pueden ser menor que la suma de los depósitos, las utilidades y el aporte al CAM");

        RuleFor(model => model.FemaleEmployeeCount)
            .LessThanOrEqualTo(model => model.EmployeeCount)
            .WithMessage("Los cantidad de empleados de sexo femenino no puede ser superior al totalde trabajadores");

        RuleFor(model => model.DiscapacityEmployeeCount)
            .LessThanOrEqualTo(model => model.EmployeeCount)
            .WithMessage("Los cantidad de empleados con necesidades especiales no puede ser superior al totalde trabajadores");
    }
}
