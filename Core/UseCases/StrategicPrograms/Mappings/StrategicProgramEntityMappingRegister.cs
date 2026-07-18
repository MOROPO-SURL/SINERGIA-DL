using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Mappings;

internal sealed class StrategicProgramEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, StrategicProgramId>()
            .MapWith(src => new StrategicProgramId(src));

        config.NewConfig<StrategicProgramId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, ProgramSpecificObjectiveId>()
            .MapWith(src => new ProgramSpecificObjectiveId(src));

        config.NewConfig<ProgramSpecificObjectiveId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, ProgramImpactId>()
            .MapWith(src => new ProgramImpactId(src));

        config.NewConfig<ProgramImpactId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, ProgramActionId>()
            .MapWith(src => new ProgramActionId(src));

        config.NewConfig<ProgramActionId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<ProgramActionIndicatorId, Guid>().MapWith(src => src.Value);

        config.NewConfig<StrategicProgram, StrategicProgramBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgram, StrategicProgramDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.SpecificObjectives, src => src.SpecificObjectives.OrderBy(entity => entity.Index).OrderBy(entity => entity.Index).Select(entity => entity.Adapt<SpecificObjectiveClippedDetailDto>()).ToArray())
            .Map(dest => dest.Organizations, src => src.OrganizationBridges.OrderBy(bridge => bridge.Linked!.Priority).Select(bridge => bridge.Linked.Adapt<OrganizationBasicDto>()).ToArray())
            .Map(dest => dest.Macroprograms, src => src.MacroprogramBridges.OrderBy(bridge => bridge.Linked!.Index).Select(bridge => bridge.Linked.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgramDetailQuery, StrategicProgramId>()
            .MapWith(src => new StrategicProgramId(src.Id));

        config.NewConfig<StrategicProgramCreateCommand, StrategicProgram>()
            .MapWith(src => new(
                new StrategicProgramId(src.Id),
                new Domain.Aggretates.StrategicLineAggregate.Values.StrategicLineId(src.LineId),
                src.IsEnabled,
                src.Name,
                false,
                src.Priority,
                new Domain.Aggretates.PersonAggregate.Values.PersonId(src.CoordinatorId),
                src.Objective,
                src.SpecificObjectives.Select(item => new ProgramSpecificObjective(new ProgramSpecificObjectiveId(Guid.NewGuid()), new StrategicProgramId(src.Id), item.Index, item.Content, Array.Empty<ProgramSpecificObjectiveStrategicProjectBridge>())).ToArray(),
                src.Actions.Select(item => new ProgramAction(
                    new(item.Id), 
                    new(src.Id), 
                    item.Title, 
                    item.Priority, 
                    item.Indicators.Select(_item => new ProgramActionIndicator(
                        new(_item.Id), 
                        new(item.Id), 
                        new(src.Id), 
                        _item.Name, 
                        new(_item.UnitMeasurement.Id), 
                        Array.Empty<ProgramActionIndicatorMilestone>(),
                        _item.Alias, null)).ToArray(),
                    Array.Empty<ProgramActionInterestAreaBridge>(),
                    item.Description)).ToArray(),
                src.Impacts.Select(item => item.Adapt<ProgramImpact>()).ToArray(),
                src.Organizations.Select(item => new StrategicProgramOrganizationBridge(new StrategicProgramId(src.Id), new OrganizationId(item.Id), null)).ToArray(),
                src.Macroprograms.Select(item => new StrategicProgramMacroprogramBridge(new StrategicProgramId(src.Id), new MacroprogramId(item.Id), null)).ToArray(),
                null,
                null,
                src.Description
            ));

        config.NewConfig<SpecificObjectiveClippedDetailDto, ProgramSpecificObjective>()
            .Map(dest => dest.Id, src => new ProgramSpecificObjectiveId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ActionClippedDetailDto, ProgramAction>()
            .Map(dest => dest.Id, src => new ProgramActionId(src.Id))
            .Map(dest => dest, src => src);

        _ = config.NewConfig<StrategicProgramUpdateCommand, StrategicProgram>()
            .Map(dest => dest.Id, src => new StrategicProgramId(src.Id))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
            {
                #region Specific Objectives

                foreach (var item in src.InSpecificObjectives)
                {
                    ProgramSpecificObjective entity = new(new ProgramSpecificObjectiveId(Guid.NewGuid()), dest.Id, item.Index, item.Content, []);

                    dest.AddSpecificObjective(entity);
                }

                foreach (var item in src.OutSpecificObjectives)
                {
                    ProgramSpecificObjective entity = item.Adapt<ProgramSpecificObjective>();

                    entity.ProgramId = dest.Id;

                    dest.RemoveSpecificObjective(entity);
                }

                foreach (var item in src.PatchSpecificObjectives)
                {
                    ProgramSpecificObjective target = dest.SpecificObjectives.First(entity => entity.Id.Value == item.Id);

                    target.Index = item.Index;
                    target.Content = item.Content;
                }

                #endregion

                #region Impacts

                foreach (var item in src.InImpacts)
                {
                    ProgramImpact entity = item.Adapt<ProgramImpact>();

                    entity.ProgramId = dest.Id;

                    dest.AddImpact(entity);
                }

                foreach (var item in src.OutImpacts)
                {
                    ProgramImpact entity = item.Adapt<ProgramImpact>();

                    entity.ProgramId = dest.Id;

                    dest.RemoveImpact(entity);
                }

                foreach (var item in src.PatchImpacts)
                {
                    ProgramImpact target = dest.Impacts.First(entity => entity.Id.Value == item.Id);

                    target.Name = item.Name;
                    target.Priority = item.Priority;
                    target.Description = item.Description;
                }

                #endregion

                #region Actions

                foreach (var item in src.InActions)
                {
                    ProgramAction entity = new(new(item.Id), dest.Id, item.Title, item.Priority, [], [], item.Description);

                    dest.AddAction(entity);
                }

                foreach (var item in src.OutActions)
                {
                    ProgramAction entity = item.Adapt<ProgramAction>();

                    entity.ProgramId = dest.Id;

                    dest.RemoveAction(entity);
                }

                foreach (var item in src.PatchActions)
                {
                    ProgramAction entity = dest.Actions.First(_entity => _entity.Id.Value == item.Id && _entity.ProgramId == dest.Id);

                    entity.Title = item.Title;
                    entity.Priority = item.Priority;
                    entity.Description = item.Description;

                    foreach (var _item in item.InIndicators)
                    {
                        ProgramActionIndicator _entity = new(new(_item.Id), entity.Id, dest.Id, _item.Name, new(_item.UnitMeasurement.Id), [], _item.Alias);

                        entity.AddIndicator(_entity);
                    }

                    foreach (var _item in item.OutIndicators)
                    {
                        ProgramActionIndicator _entity = _item.Adapt<ProgramActionIndicator>();

                        _entity.ActionId = entity.Id;
                        _entity.ProgramId = dest.Id;

                        entity.RemoveIndicator(_entity);
                    }

                    foreach (var _item in item.PatchIndicators)
                    {
                        ProgramActionIndicator _entity = entity.Indicators.First(_entity => _entity.Id.Value == _item.Id && _entity.ActionId == entity.Id && _entity.ProgramId == dest.Id);

                        _entity.Name = _item.Name;
                        _entity.Alias = _item.Alias;
                        
                        if (_entity.UnitMeasurementId.Value != _item.UnitMeasurement.Id)
                        {
                            _entity.UnitMeasurement = null;
                            _entity.UnitMeasurementId = new(_item.UnitMeasurement.Id);
                        }
                    }
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
}