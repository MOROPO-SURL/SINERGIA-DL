using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.Mappings;

internal class RoleCreateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RoleCreateCommand, Role>()
            .Map(dest => dest.Id, src => new RoleId(Guid.NewGuid()))
            .Map(dest => dest, src => src);
    }
}
