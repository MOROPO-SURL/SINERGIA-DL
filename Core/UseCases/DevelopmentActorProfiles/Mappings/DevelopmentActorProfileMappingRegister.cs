using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
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

        config.NewConfig<SRLDevelopmentActorProfile, SRLDevelopmentActorProfileDetailDto>()
            .Map(dest => dest.OrganizationPartners, src => src.OrganizationBridges.Select(bridge => bridge.Linked.Adapt<OrganizationBasicDto>()))
            .Map(dest => dest.PersonPartners, src => src.PersonBridges.Select(bridge => bridge.Linked.Adapt<PersonBasicDto>()))
            .Map(dest => dest.SecoundaryEconomicActivities, src => src.SecoundaryEconomicActivityBridges.Select(bridge => bridge.Linked.Adapt<EconomicActivityBasicDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<SRLDevelopmentActorProfileCreateCommand, SRLDevelopmentActorProfile>()
            .MapWith(src => new SRLDevelopmentActorProfile(
                new DevelopmentActorProfileId(src.Id),
                false,
                src.IsEnabled,
                new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(src.OwnerId),
                src.FiscalIdentificationCode,
                src.BornAt,
                new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(src.MainEconomicActivityId),
                src.SecoundaryEconomicActivityIds.Select(item => new DevelopmentActorProfileEconomicActivityBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item), null)),
                Array.Empty<DevelopmentActorProfileProductionActivity>(),
                Array.Empty<DevelopmentActorProfileCommercialActivity>(),
                Array.Empty<DevelopmentActorProfileServicingActivity>(),
                src.OrganizationPartnerIds.Select(item => new SRLDevelopmentActorProfileOrganizationBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(item), null)),
                src.PersonPartnerIds.Select(item => new SRLDevelopmentActorProfilePersonBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.PersonAggregate.Values.PersonId(item), null)),
                src.About,
                null,
                null));

        config.NewConfig<SRLDevelopmentActorProfileUpdateCommand, SRLDevelopmentActorProfile>()
            .AfterMapping((src, dest) =>
            {
                foreach (int item in src.InSecoundaryEconomicActivityIds)
                {
                    dest.LinkSecoundaryEconomicActivityById(new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item));
                }
                foreach (int item in src.OutSecoundaryEconomicActivityIds)
                {
                    dest.UnlinkSecoundaryEconomicActivityById(new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item));
                }

                foreach (Guid item in src.InOrganizationPartnerIds)
                {
                    dest.LinkOrganizationById(new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(item));
                }
                foreach (Guid item in src.OutOrganizationPartnerIds)
                {
                    dest.UnlinkOrganizationById(new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(item));
                }

                foreach (Guid item in src.InPersonPartnerIds)
                {
                    dest.LinkPersonById(new Domain.Aggretates.PersonAggregate.Values.PersonId(item));
                }
                foreach (Guid item in src.OutPersonPartnerIds)
                {
                    dest.UnlinkPersonById(new Domain.Aggretates.PersonAggregate.Values.PersonId(item));
                }
            });
    }
}
