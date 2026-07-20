using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.DTOs;

public record OrganizationKindTraceBasicDto (long Id, TraceKind Kind, DateTime CreatedAt, string Author) : IDto;
