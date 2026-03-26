using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.TraceAggregate;

public class PersonTrace : Abstractions.AbstractTrace<PersonAggregate.Person, PersonAggregate.PersonId>
{
    public PersonTrace(IDataIntegrityServicePort dataIntegrityService, TraceId id, Enumerations.TraceKind kind, string author, DateTime createAt, PersonAggregate.Person person, PersonAggregate.PersonId personId, string? beforeData, string? afterData) : base(dataIntegrityService, id, kind, author, createAt, person, personId, beforeData, afterData)
    {
    }
}
