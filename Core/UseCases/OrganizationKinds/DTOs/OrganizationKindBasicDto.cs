using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;

public record OrganizationKindBasicDto(Guid Id, bool IsEnabled, string Name, DevelopmentActorProfileKind? DevelopmentActorProfileKind) : IDto;
