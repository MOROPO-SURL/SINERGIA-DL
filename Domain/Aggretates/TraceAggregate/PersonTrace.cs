using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;

public class PersonTrace : Abstractions.AbstractTrace<PersonAggregate.Person, PersonId, Guid>
{
    private PersonTrace() { }

    public PersonTrace(TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, string signature, string? beforeData = null, string? afterData = null, PersonId? personId = null, PersonAggregate.Person? person = null) : base(id, kind, author, createAt, signature, beforeData, afterData, personId, person)
    {
    }
}