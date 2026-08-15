using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Models.Page.OperationReport;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME.Validators;

public sealed class OperationReportConfigurationValidator : AbstractValidator<OperationReportConfigurationPageModel>
{
    public OperationReportConfigurationValidator()
    {
        RuleFor(model => model.Description)
            .MaximumLength(1024)
            .WithName("Descripción");

        RuleFor(model => model.IncomeSummary)
            .GreaterThanOrEqualTo(model => model.IncomeEcommerce + model.IncomeBankDeposit)
            .WithMessage("Los ingresos totales no pueden ser menor que la suma de sus aperturas");

        RuleFor(model => model.SpendSummary)
            .GreaterThanOrEqualTo(model => model.SpendPrivateSector + model.SpendPublicSector + model.HumanResourcePayload)
            .WithMessage("Los gastos totales no pueden ser menor que la suma de sus aperturas");

        RuleFor(model => model.FemaleEmployeeCount)
            .LessThanOrEqualTo(model => model.EmployeeCount)
            .WithMessage("Los cantidad de empleados de sexo femenino no puede ser superior al totalde trabajadores");

        RuleFor(model => model.DiscapacityEmployeeCount)
            .LessThanOrEqualTo(model => model.EmployeeCount)
            .WithMessage("Los cantidad de empleados con necesidades especiales no puede ser superior al totalde trabajadores");
    }
}
