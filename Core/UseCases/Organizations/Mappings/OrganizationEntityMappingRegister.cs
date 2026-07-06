using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.Mappings;

internal sealed class OrganizationEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrganizationId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, OrganizationId>()
            .MapWith(src => new OrganizationId(src));

        config.NewConfig<Organization, OrganizationBasicDto>()
            .Map(dest => dest.Image, src => src.Image.Adapt<ImageBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<Organization, OrganizationDetailDto>()
            .Map(dest => dest.Image, src => src.Image.Adapt<ImageBasicDto>())
            .Map(dest => dest.RepresentativePersons, src => src.PersonBridges.Where(bridge => bridge.IsRepresentative).Select(bridge => bridge.Main.Adapt<PersonBasicDto>()))
            .Map(dest => dest.NonRepresentativePersons, src => src.PersonBridges.Where(bridge => !bridge.IsRepresentative).Select(bridge => bridge.Main.Adapt<PersonBasicDto>()))
            .Map(dest => dest, src => src);

        config.NewConfig<OrganizationCreateCommand, Organization>()
            .MapWith(src => new(
                new OrganizationId(Guid.NewGuid()),
                false,
                src.IsEnabled,
                src.Name,
                src.Priority,
                new OrganizationKindId(src.KindId),
                src.EmailAddresses.Select(item => item.Adapt<EmailAddress>()).ToArray(),
                src.PhoneNumbers.Select(item => item.Adapt<PhoneNumber>()).ToArray(),
                src.PostalAddresses.Select(item => item.Adapt<PostalAddress>()).ToArray(),
                src.WebSiteAddresses.Select(item => item.Adapt<WebSiteAddress>()).ToArray(),
                Array.Empty<PersonOrganizationBrigde>(),
                Array.Empty<OrganizationClassificationBridge>(),
                null,
                null,
                null,
                src.About,
                null,
                null
            )).AfterMapping((src, dest) =>
            {
                foreach (var item in src.PersonRelationships)
                {
                    dest.LinkPersonById(new Domain.Aggretates.PersonAggregate.Values.PersonId(item.PersonId), item.IsRepresentative);
                }
            });

        config.NewConfig<OrganizationUpdateCommand, Organization>()
            .Map(dest => dest.KindId, src => new OrganizationKindId(src.KindId))
            .AfterMapping((src, dest) =>
            {
                foreach (PhoneNumberDetailDto item in src.InPhoneNumbers)
                {
                    dest.Add(item.Adapt<PhoneNumber>());
                }

                foreach (PhoneNumberDetailDto item in src.OutPhoneNumbers)
                {
                    dest.Remove(item.Adapt<PhoneNumber>());
                }

                foreach (EmailAddressDetailDto item in src.InEmailAddresses)
                {
                    dest.Add(item.Adapt<EmailAddress>());
                }

                foreach (EmailAddressDetailDto item in src.OutEmailAddresses)
                {
                    dest.Remove(item.Adapt<EmailAddress>());
                }

                foreach (var item in src.InPostalAddresses)
                {
                    dest.Add(item.Adapt<PostalAddress>());
                }

                foreach (var item in src.OutPostalAddresses)
                {
                    dest.Remove(item.Adapt<PostalAddress>());
                }

                foreach (var item in src.InWebSiteAddresses)
                {
                    dest.Add(item.Adapt<WebSiteAddress>());
                }

                foreach (var item in src.OutWebSiteAddresses)
                {
                    dest.Remove(item.Adapt<WebSiteAddress>());
                }

                foreach (var item in src.InPersonRelationships)
                {
                    dest.LinkPersonById(new Domain.Aggretates.PersonAggregate.Values.PersonId(item.PersonId), item.IsRepresentative);
                }

                foreach (var item in src.PatchPersonRelationships)
                {
                    var bridge = dest.PersonBridges.Single(bridge => bridge.MainId.Value == item.PersonId);

                    bridge.IsRepresentative = item.IsRepresentative;
                }

                foreach (var item in src.OutPersonRelationships)
                {
                    dest.UnlinkPersonById(new Domain.Aggretates.PersonAggregate.Values.PersonId(item.Id));
                }
            });
    }
}
