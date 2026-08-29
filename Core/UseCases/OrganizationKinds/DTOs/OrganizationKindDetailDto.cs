using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;

public record OrganizationKindDetailDto(
    Guid Id, 
    bool IsEnabled, 
    string Name, 
    int Priority,
    DevelopmentActorProfileKind? DevelopmentActorProfileKind = null,
    string? Description = null) : IDetailDto;
