using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Query.Detail;

public record PersonDetailQuery(Guid Id) : IDetailQuery<PersonId, Guid, PersonDetailDto>;