using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Mappings;

internal sealed class OperationReportMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OperationReportId, long>().MapWith(src => src.Value);

        config.NewConfig<long, OperationReportId>().MapWith(src => new OperationReportId(src));

        config.NewConfig<SRLOperationReport, SRLOperationReportBasicDto>()
            .Map(dest => dest.Organization, src => src.Owner!.Owner.Adapt<OrganizationBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<SRLOperationReport, SRLOperationReportDetailDto>()
            .Map(dest => dest.Organization, src => src.Owner!.Owner.Adapt<OrganizationBasicDto>())
            .Map(dest => dest.IncomeSummaryEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.IncomeSummary).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.IncomeEcommerceEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.IncomeEcommerce).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.IncomeBankDepositEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.IncomeBankDeposit).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.SpendSummaryEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.SpendSummary).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.SpendPrivateSectorEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.SpendPrivateSector).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.SpendPublicSectorEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.SpendPublicSector).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.PeriodResultEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.PeriodResult).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.OperativeTaxEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.OperativeTax).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.SellTaxEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.SellTax).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.HumanResourcePayloadEntries, src => src.AccountingEntries.Where(entity => entity.Kind == OperationReportAccountingEntryKind.HumanResourcePayload).GroupBy(entity => entity.Currency).Select(group => new KeyValuePair<OperationReportAccountingEntryCurrency, float>(group.Key, group.First().Amount)))
            .Map(dest => dest.Documents, src => src.DocumentBridges.Select(bridge => bridge.Linked.Adapt<DocumentBasicDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<PDLOperationReport, PDLOperationReportBasicDto>()
            .Map(dest => dest.Organization, src => src.Owner!.Owner.Adapt<OrganizationBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<PDLOperationReport, PDLOperationReportDetailDto>()
            .Map(dest => dest.Organization, src => src.Owner!.Owner.Adapt<OrganizationBasicDto>())
            .Map(dest => dest.Documents, src => src.DocumentBridges.Select(bridge => bridge.Linked.Adapt<DocumentBasicDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<SRLOperationReportCreateCommand, SRLOperationReport>().MapWith(src => Build(src));

        config.NewConfig<PDLOperationReportCreateCommand, PDLOperationReport>().MapWith(src => new PDLOperationReport(
            new OperationReportId(default),
            new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(src.OwnerId),
            DateTime.Now,
            src.Period,
            src.EmployeeCount,
            src.FemaleEmployeeCount,
            src.DiscapacityEmployeeCount,
            src.GridEnergySpend,
            src.RenerenewableEnergyGeneration,
            src.RenerenewableEnergyExportation,
            src.Income,
            src.IncomeBankDeposit,
            src.PeriodResult,
            src.CAMComission,
            Array.Empty<OperationReportDocumentBridge>(),
            src.Description,
            null));
    }

    private static SRLOperationReport Build(SRLOperationReportCreateCommand model)
    {
        OperationReportId id = new(default);

        List<OperationReportAccountingEntry> accountingEntries = [];

        accountingEntries.AddRange(model.IncomeSummaryEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.IncomeSummary, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.IncomeEcommerceEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.IncomeEcommerce, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.IncomeBankDepositEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.IncomeBankDeposit, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.SpendSummaryEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.SpendSummary, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.SpendPublicSectorEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.SpendPublicSector, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.SpendPrivateSectorEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.SpendPrivateSector, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.PeriodResultEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.PeriodResult, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.SellTaxEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.SellTax, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.OperativeTaxEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.OperativeTax, id, item.Key, item.Value)));
        accountingEntries.AddRange(model.HumanResourcePayloadEntries.Select(item => new OperationReportAccountingEntry(OperationReportAccountingEntryKind.HumanResourcePayload, id, item.Key, item.Value)));

        return new SRLOperationReport(
            id,
            new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(model.OwnerId),
            DateTime.Now,
            model.Period,
            model.EmployeeCount,
            model.FemaleEmployeeCount,
            model.DiscapacityEmployeeCount,
            model.GridEnergySpend,
            model.RenerenewableEnergyGeneration,
            model.RenerenewableEnergyExportation,
            accountingEntries,
            Array.Empty<OperationReportDocumentBridge>(),
            model.Description,
            null);
    }
}
