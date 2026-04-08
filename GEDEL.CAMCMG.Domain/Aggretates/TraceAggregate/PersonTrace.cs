using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class PersonTrace : Abstractions.AbstractTrace<PersonAggregate.Person, PersonId, Guid>
{
    public PersonTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, PersonAggregate.Person person, PersonId personId, string signature, string? beforeData, string? afterData) : base(id, kind, author, createAt, person, personId, signature, beforeData, afterData)
    {
    }
}