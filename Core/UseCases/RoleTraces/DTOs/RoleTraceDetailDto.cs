using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;

public record RoleTraceDetailDto(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null) : IDetailDto;