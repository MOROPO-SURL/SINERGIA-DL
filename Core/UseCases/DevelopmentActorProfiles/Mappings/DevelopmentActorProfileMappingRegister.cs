using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Mappings;

internal sealed class DevelopmentActorProfileMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DevelopmentActorProfileId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, DevelopmentActorProfileId>()
            .MapWith(src => new DevelopmentActorProfileId(src));

        config.NewConfig<SRLDevelopmentActorProfileCreateCommand, SRLDevelopmentActorProfile>()
            .MapWith(src => new SRLDevelopmentActorProfile(
                new DevelopmentActorProfileId(src.Id),
                false,
                src.IsEnabled,
                new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(src.OwnerId),
                new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(src.MainEconomicActivityId),
                src.SecoundaryEconomicActivities.Select(item => new DevelopmentActorProfileEconomicActivityBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item), null)),
                Array.Empty<DevelopmentActorProfileProductionActivity>(),
                Array.Empty<DevelopmentActorProfileCommercialActivity>(),
                Array.Empty<DevelopmentActorProfileServicingActivity>(),
                Array.Empty<SRLDevelopmentActorProfileOrganizationBridge>(),
                Array.Empty<SRLDevelopmentActorProfilePersonBridge>(),
                src.About,
                null,
                null));

        config.NewConfig<SRLDevelopmentActorProfileUpdateCommand, SRLDevelopmentActorProfile>()
            .AfterMapping((src, dest) =>
            {
                foreach (int item in src.InSecoundaryEconomicActivities)
                {
                    dest.LinkSecoundaryEconomicActivityById(new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item));
                }

                foreach (int item in src.OutSecoundaryEconomicActivities)
                {
                    dest.UnlinkSecoundaryEconomicActivityById(new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item));
                }
            });
    }
}
