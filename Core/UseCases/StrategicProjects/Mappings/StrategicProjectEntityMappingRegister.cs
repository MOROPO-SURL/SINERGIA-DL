using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using System.Linq;
using System;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Mappings;

internal sealed class StrategicProjectEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, StrategicProjectId>()
            .MapWith(src => new StrategicProjectId(src));

        config.NewConfig<StrategicProjectId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, ProjectSpecificObjectiveId>()
            .MapWith(src => new ProjectSpecificObjectiveId(src));

        config.NewConfig<ProjectSpecificObjectiveId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Guid, ProjectIndicatorId>()
            .MapWith(src => new ProjectIndicatorId(src));

        config.NewConfig<ProjectIndicatorId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<ProjectIndicatorMilestoneId, Guid>().MapWith(src => src.Value);

        config.NewConfig<StrategicProject, StrategicProjectBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProject, StrategicProjectDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.SpecificObjectives, src => src.SpecificObjectives.OrderBy(entity => entity.Index).OrderBy(entity => entity.Index).Select(entity => entity.Adapt<SpecificObjectiveProjectClippedDetailDto>()).ToArray())
            .Map(dest => dest.Macroprograms, src => src.MacroprogramBridges.OrderBy(bridge => bridge.Linked!.Index).Select(bridge => bridge.Linked.Adapt<MacroprogramBasicDto>()).ToArray())
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectDetailQuery, StrategicProjectId>()
            .MapWith(src => new StrategicProjectId(src.Id));

        config.NewConfig<StrategicProjectCreateCommand, StrategicProject>()
            .MapWith(src => new(
                new StrategicProjectId(src.Id),
                new Domain.Aggretates.StrategicProjectKindAggregate.Values.StrategicProjectKindId(src.KindId),
                new StrategicProgramId(src.ProgramId),
                src.IsEnabled,
                false,
                src.Name,
                src.Objective,
                src.Priority,
                src.SpecificObjectives.Select(item => new ProjectSpecificObjective(
                    new ProjectSpecificObjectiveId(Guid.NewGuid()), 
                    new StrategicProjectId(src.Id), 
                    item.Index, 
                    item.Content)).ToArray(),
                src.Indicators.Select(_item => new ProjectIndicator(
                        new(_item.Id),
                        new(src.Id),
                        _item.Name,
                        new(_item.UnitMeasurement.Id),
                        src.Priority,
                        _item.Milestones.Select(__item => new ProjectIndicatorMilestone(
                            new(__item.Id),
                            new(_item.Id),
                            new(src.Id),
                            __item.At,
                            __item.Amount,
                            __item.Description)),
                        _item.Alias, null)).ToArray(),
                src.Macroprograms.Select(item => new StrategicProjectMacroprogramBridge(new StrategicProjectId(src.Id), new MacroprogramId(item.Id), null)).ToArray(),
                null,
                null,
                null
            ));

        config.NewConfig<SpecificObjectiveProjectClippedDetailDto, ProjectSpecificObjective>()
            .Map(dest => dest.Id, src => new ProjectSpecificObjectiveId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<IndicatorClippedDetailDto, ProjectIndicator>()
            .Map(dest => dest.Id, src => new ProjectIndicatorId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProjectUpdateCommand, StrategicProject>()
            .Map(dest => dest.Id, src => new StrategicProjectId(src.Id))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
             {
                 #region Specific Objectives

                 foreach (var item in src.InSpecificObjectives)
                 {
                     ProjectSpecificObjective entity = new(new ProjectSpecificObjectiveId(Guid.NewGuid()), dest.Id, item.Index, item.Content);

                     dest.AddSpecificObjective(entity);
                 }

                 foreach (var item in src.OutSpecificObjectives)
                 {
                     ProjectSpecificObjective entity = item.Adapt<ProjectSpecificObjective>();

                     entity.ProjectId = dest.Id;

                     dest.RemoveSpecificObjective(entity);
                 }

                 foreach (var item in src.PatchSpecificObjectives)
                 {
                     ProjectSpecificObjective target = dest.SpecificObjectives.First(entity => entity.Id.Value == item.Id);

                     target.Index = item.Index;
                     target.Content = item.Content;
                 }

                 #endregion

                 #region Indicators

                 foreach (var item in src.InIndicators)
                 {
                     ProjectIndicatorId indicatorId = new(item.Id);

                     ProjectIndicator _entity = new(
                         indicatorId,
                         dest.Id,
                         item.Name,
                         new(item.UnitMeasurement.Id),
                         item.Priority,
                         item.Milestones.Select(_item => new ProjectIndicatorMilestone(
                            new(_item.Id),
                             indicatorId,
                             dest.Id,
                             _item.At,
                             _item.Amount,
                         _item.Description)),
                         item.Alias);

                     dest.AddIndicator(_entity);
                 }

                 foreach (var item in src.OutIndicators)
                 {
                     ProjectIndicator entity = item.Adapt<ProjectIndicator>();

                     entity.ProjectId = dest.Id;

                     dest.RemoveIndicator(entity);
                 }
                 foreach (var item in src.PatchIndicators)
                 {
                     ProjectIndicator entity = dest.Indicators.First(entity => entity.Id.Value == item.Id && entity.ProjectId == dest.Id);
                     entity.Name = item.Name;
                     entity.Alias = item.Alias;

                     if (entity.UnitMeasurementId.Value != item.UnitMeasurement.Id)
                     {
                         entity.UnitMeasurement = null;
                         entity.UnitMeasurementId = new(item.UnitMeasurement.Id);
                     }

                     foreach (var _item in item.InMilestones)
                     {
                         ProjectIndicatorMilestone _entity = new(new(_item.Id), entity.Id, dest.Id, _item.At, _item.Amount, _item.Description);

                         entity.AddMilestone(_entity);
                     }

                     foreach (var _item in item.OutMilestones)
                     {
                         ProjectIndicatorMilestone _entity = item.Adapt<ProjectIndicatorMilestone>();

                         _entity.IndicatorId = entity.Id;
                         _entity.ProjectId = dest.Id;

                         entity.RemoveMilestone(_entity);
                     }

                     foreach (var _item in item.PatchMilestones)
                     {
                         ProjectIndicatorMilestone _entity = entity.Milestones.First(_entity => _entity.Id.Value == _item.Id && _entity.IndicatorId == entity.Id && _entity.ProjectId == dest.Id);

                         _entity.At = _item.At;
                         _entity.Amount = _item.Amount;
                         _entity.Description = _item.Description;
                     }
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