using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.StrategicLines.Mappings;

public class StrategicLineMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StrategicLineCreateRequestModel, StrategicLineCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.SpecificObjectives, src => src.SpecificObjectives.Select(item => item.Adapt<SpecificObjectiveClippedCreateCommand>()).ToArray())
            .Map(dest => dest.PublicPolicies, src => src.PublicPolicies.Select(item => item.Adapt<PublicPolicyBasicDto>()).ToArray())
            .Map(dest => dest.Organizations, src => src.Organizations.Select(item => item.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.Macroprograms, src => src.Macroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineUpdateRequestModel, StrategicLineUpdateCommand>()
            .Map(dest => dest.InSpecificObjectives, src => src.InSpecificObjectives.Select(item => item.Adapt<SpecificObjectiveClippedCreateCommand>()).ToArray())
            .Map(dest => dest.PatchSpecificObjectives, src => src.PathcSpecificObjectives.Select(item => item.Adapt<SpecificObjectiveClippedUpdateCommand>()).ToArray())
            .Map(dest => dest.OutSpecificObjectives, src => src.OutSpecificObjective.Select(item => item.Adapt<StrategicLineSpecificObjectiveDetailDto>()).ToArray())
            .Map(dest => dest.InPublicPolicies, dest => dest.InPublicPolicies.Select(item => item.Adapt<PublicPolicyBasicDto>()).ToArray())
            .Map(dest => dest.OutPublicPolicies, dest => dest.OutPublicPolicies.Select(item => item.Adapt<PublicPolicyBasicDto>()).ToArray())
            .Map(dest => dest.InOrganizations, dest => dest.InOrganizations.Select(item => item.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.OutOrganizations, dest => dest.OutOrganizations.Select(item => item.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.InMacroprograms, dest => dest.InMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest.OutMacroprograms, dest => dest.OutMacroprograms.Select(item => item.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);
    }
}
