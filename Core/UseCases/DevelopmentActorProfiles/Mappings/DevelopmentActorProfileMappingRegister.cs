using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Mappings;

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
            .Map(dest => dest.CommercialLocations, src => src.LocationBridges.Select(bridge => bridge.Linked.Adapt<LocationDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<LegalOwnedPDLDevelopmentActorProfile, LegalOwnedPDLDevelopmentActorProfileDetailDto>()
            .Map(dest => dest.SecoundaryEconomicActivities, src => src.SecoundaryEconomicActivityBridges.Select(bridge => bridge.Linked.Adapt<EconomicActivityBasicDto>()))
            .Map(dest => dest.CommercialLocations, src => src.LocationBridges.Select(bridge => bridge.Linked.Adapt<LocationDetailDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<NaturalOwnedPDLDevelopmentActorProfile, NaturalOwnedPDLDevelopmentActorProfileDetailDto>()
            .Map(dest => dest.SecoundaryEconomicActivities, src => src.SecoundaryEconomicActivityBridges.Select(bridge => bridge.Linked.Adapt<EconomicActivityBasicDto>()))
            .Map(dest => dest.CommercialLocations, src => src.LocationBridges.Select(bridge => bridge.Linked.Adapt<LocationDetailDto>()))
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
                new Domain.Aggretates.LocationAggregate.Values.LocationId(src.MainLocationId),
                src.SecoundaryEconomicActivityIds.Select(item => new DevelopmentActorProfileEconomicActivityBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item), null)),
                Array.Empty<DevelopmentActorProfileLocationBridge>(),
                Array.Empty<DevelopmentActorProfileProductionActivity>(),
                Array.Empty<DevelopmentActorProfileCommercialActivity>(),
                Array.Empty<DevelopmentActorProfileServicingActivity>(),
                src.OrganizationPartnerIds.Select(item => new SRLDevelopmentActorProfileOrganizationBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(item), null)),
                src.PersonPartnerIds.Select(item => new SRLDevelopmentActorProfilePersonBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.PersonAggregate.Values.PersonId(item), null)),
                src.About,
                null,
                null,
                null));

        config.NewConfig<LegalOwnedPDLDevelopmentActorProfileCreateCommand, LegalOwnedPDLDevelopmentActorProfile>()
            .MapWith(src => new LegalOwnedPDLDevelopmentActorProfile(
                new DevelopmentActorProfileId(src.Id),
                false,
                src.IsEnabled,
                new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(src.OwnerId),
                src.FiscalIdentificationCode,
                src.BornAt,
                new Domain.Aggretates.PDLModalityAggregate.Values.PDLModalityId(src.ModalityId),
                new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(src.MainEconomicActivityId),
                new Domain.Aggretates.LocationAggregate.Values.LocationId(src.MainLocationId),
                src.SecoundaryEconomicActivityIds.Select(item => new DevelopmentActorProfileEconomicActivityBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item), null)),
                Array.Empty<DevelopmentActorProfileLocationBridge>(),
                Array.Empty<DevelopmentActorProfileProductionActivity>(),
                Array.Empty<DevelopmentActorProfileCommercialActivity>(),
                Array.Empty<DevelopmentActorProfileServicingActivity>(),
                new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(src.HolderId),
                src.About,
                null,
                null,
                null,
                null,
                null));

        config.NewConfig<NaturalOwnedPDLDevelopmentActorProfileCreateCommand, NaturalOwnedPDLDevelopmentActorProfile>()
            .MapWith(src => new NaturalOwnedPDLDevelopmentActorProfile(
                new DevelopmentActorProfileId(src.Id),
                false,
                src.IsEnabled,
                new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(src.OwnerId),
                src.FiscalIdentificationCode,
                src.BornAt,
                new Domain.Aggretates.PDLModalityAggregate.Values.PDLModalityId(src.ModalityId),
                new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(src.MainEconomicActivityId),
                new Domain.Aggretates.LocationAggregate.Values.LocationId(src.MainLocationId),
                src.SecoundaryEconomicActivityIds.Select(item => new DevelopmentActorProfileEconomicActivityBridge(new DevelopmentActorProfileId(src.Id), new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item), null)),
                Array.Empty<DevelopmentActorProfileLocationBridge>(),
                Array.Empty<DevelopmentActorProfileProductionActivity>(),
                Array.Empty<DevelopmentActorProfileCommercialActivity>(),
                Array.Empty<DevelopmentActorProfileServicingActivity>(),
                new Domain.Aggretates.PersonAggregate.Values.PersonId(src.HolderId),
                src.About,
                null,
                null,
                null,
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
                    dest.RemoveSecoundaryEconomicActivityBridge(dest.SecoundaryEconomicActivityBridges.First(bridge => bridge.LinkedId.Value == item));
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

        config.NewConfig<LegalOwnedPDLDevelopmentActorProfileUpdateCommand, LegalOwnedPDLDevelopmentActorProfile>()
            .AfterMapping((src, dest) =>
            {
                foreach (int item in src.InSecoundaryEconomicActivityIds)
                {
                    dest.LinkSecoundaryEconomicActivityById(new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item));
                }
                foreach (int item in src.OutSecoundaryEconomicActivityIds)
                {
                    dest.RemoveSecoundaryEconomicActivityBridge(dest.SecoundaryEconomicActivityBridges.First(bridge => bridge.LinkedId.Value == item));
                }
            });

        config.NewConfig<NaturalOwnedPDLDevelopmentActorProfileUpdateCommand, NaturalOwnedPDLDevelopmentActorProfile>()
            .AfterMapping((src, dest) =>
            {
                foreach (int item in src.InSecoundaryEconomicActivityIds)
                {
                    dest.LinkSecoundaryEconomicActivityById(new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(item));
                }
                foreach (int item in src.OutSecoundaryEconomicActivityIds)
                {
                    dest.RemoveSecoundaryEconomicActivityBridge(dest.SecoundaryEconomicActivityBridges.First(bridge => bridge.LinkedId.Value == item));
                }
            });
    }
}
