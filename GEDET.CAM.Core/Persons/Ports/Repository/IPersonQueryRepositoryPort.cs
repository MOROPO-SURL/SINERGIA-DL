using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.Persons.Ports.Repository;

public interface IPersonQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Person, PersonId>
{
}
