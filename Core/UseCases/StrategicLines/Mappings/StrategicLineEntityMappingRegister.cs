using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Mappings;

internal sealed class StrategicLineEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // TODO Remove !!!
        //config.NewConfig<StrategicLineDetailDto, StrategicLineSpecificObjective>()
        //    .Map(dest => dest.Id, src => new StrategicLineSpecificObjectiveId(src.Id))
        //    .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineSpecificObjective, StrategicLineSpecificObjectiveDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<SpecificObjectiveClippedCreateCommand, StrategicLineSpecificObjective>()
            .Map(dest => dest.Id, src => new StrategicLineSpecificObjectiveId(Guid.NewGuid()))
            .Map(dest => dest, src => src);

        config.NewConfig<Guid, StrategicLineId>()
            .MapWith(src => new StrategicLineId(src));

        config.NewConfig<StrategicLine, StrategicLineBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Axe, src => src.Axe == null ? null : src.Axe.Adapt<StrategicAxeBasicDto>())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLine, StrategicLineDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Axe, src => src.Axe == null ? null : src.Axe.Adapt<StrategicAxeBasicDto>())
            .Map(dest => dest.SpecificObjectives, src => src.SpecificObjectives.OrderBy(entity => entity.Index).Select(entity => entity.Adapt<StrategicLineSpecificObjectiveDetailDto>()).ToArray())
            .Map(dest => dest.PublicPolicies, src => src.PublicPolicyBridges.OrderBy(bridge => bridge.Linked!.PublishedAt).Select(bridge => bridge.Linked.Adapt<PublicPolicyBasicDto>()).ToArray())
            .Map(dest => dest.Organizations, src => src.OrganizationBridges.OrderBy(bridge => bridge.Linked!.Priority).Select(bridge => bridge.Linked.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.Macroprograms, src => src.MacroprogramBridges.OrderBy(bridge => bridge.Linked!.Index).Select(bridge => bridge.Linked.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicLineDetailQuery, StrategicLineId>()
            .MapWith(src => new StrategicLineId(src.Id));

        config.NewConfig<StrategicLineCreateCommand, StrategicLine>()
            .MapWith(src => new(
                new StrategicLineId(src.Id),
                src.Index,
                src.IsEnabled,
                src.Name,
                false,
                new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId),
                src.Objective,
                src.SpecificObjectives.Select(item => new StrategicLineSpecificObjective(new StrategicLineSpecificObjectiveId(Guid.NewGuid()), new StrategicLineId(src.Id), item.Index, item.Content)).ToArray(),
                Array.Empty<StrategicLineAction>(),
                src.Organizations.Select(item => new StrategicLineOrganizationBridge(new StrategicLineId(src.Id), new OrganizationId(item.Id), null)).ToArray(),
                src.PublicPolicies.Select(item => new StrategicLinePublicPolicyBridge(new StrategicLineId(src.Id), new PublicPolicyId(item.Id), null)).ToArray(),
                src.Macroprograms.Select(item => new StrategicLineMacroprogramBridge(new StrategicLineId(src.Id), new MacroprogramId(item.Id), null)).ToArray(),
                src.AxeId == null ? null : new StrategicAxeId(src.AxeId.Value),
                null,
                null,
                src.Description
            ));

        config.NewConfig<StrategicLineUpdateCommand, StrategicLine>()
            .Map(dest => dest.Id, src => new StrategicLineId(src.Id))
            .Map(dest => dest.AxeId, src => GetStrategicAxeId(src))
            .Map(dest => dest.CoordinatorId, src => new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
            {
                #region Organizations

                foreach (var item in src.InSpecificObjectives)
                {
                    dest.AddSpecificObjective(item.Adapt<StrategicLineSpecificObjective>());
                }

                foreach (var item in src.OutSpecificObjectives)
                {
                    dest.RemoveSpecificObjective(item.Adapt<StrategicLineSpecificObjective>());
                }

                foreach (var item in src.PatchSpecificObjectives)
                {
                    StrategicLineSpecificObjective target = dest.SpecificObjectives.First(entity => entity.Id.Value == item.Id);

                    target.Index = item.Index;
                    target.Content = item.Content;
                }

                #endregion

                #region PublicPolicies

                foreach (var item in src.InPublicPolicies)
                {
                    dest.LinkPublicPolicyById(new PublicPolicyId(item.Id));
                }

                foreach (var item in src.OutPublicPolicies)
                {
                    dest.UnlinkPublicPolicy(new PublicPolicyId(item.Id));
                }

                #endregion

                #region Organizations

                foreach (var item in src.InOrganizations)
                {
                    dest.LinkOrganizationById(new OrganizationId(item.Id));
                }

                foreach (var item in src.OutOrganizations)
                {
                    dest.UnlinkOrganizationById(new OrganizationId(item.Id));
                }

                #endregion

                #region Macroprograms

                foreach (var item in src.InMacroprograms)
                {
                    dest.LinkMacroprogramById(new MacroprogramId(item.Id));
                }

                foreach (var item in src.OutMacroprograms)
                {
                    dest.UnlinkMacroprogramById(new MacroprogramId(item.Id));
                }

                #endregion
            });
    }

    private static StrategicAxeId? GetStrategicAxeId(StrategicLineUpdateCommand src)
    {
        return src.AxeId == null ? null : new StrategicAxeId(src.AxeId.Value);
    }
}