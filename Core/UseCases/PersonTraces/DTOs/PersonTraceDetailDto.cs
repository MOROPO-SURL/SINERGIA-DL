using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

public record PersonTraceDetailDto(long Id, TraceKind Kind, DateTime CreatedAt, string Author, string? BeforeData = null, string? AfterData = null) : IDetailDto;