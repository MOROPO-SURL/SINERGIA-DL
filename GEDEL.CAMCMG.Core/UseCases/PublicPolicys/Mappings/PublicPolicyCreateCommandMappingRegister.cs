using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.Mappings;

internal sealed class PublicPolicyCreateCommandMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PublicPolicyCreateCommand, PublicPolicy>()
            .Map(dest => dest.Id, src => new PublicPolicyId(src.Id))
            .Map(dest => dest, src => src);
    }
}
