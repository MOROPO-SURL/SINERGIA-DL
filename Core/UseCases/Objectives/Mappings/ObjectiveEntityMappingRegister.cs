using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Mappings;

internal sealed class ObjectiveEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, ObjectiveId>().MapWith(src => new ObjectiveId(src));
        config.NewConfig<ObjectiveId, Guid>().MapWith(src => src.Value);

        config.NewConfig<Guid, ObjectiveActionId>().MapWith(src => new ObjectiveActionId(src));
        config.NewConfig<ObjectiveActionId, Guid>().MapWith(src => src.Value);

        config.NewConfig<ObjectiveActionIndicatorId, Guid>().MapWith(src => src.Value);
        config.NewConfig<ObjectiveActionIndicatorMilestoneId, Guid>().MapWith(src => src.Value);

        config.NewConfig<ObjectiveActionId, Guid>().MapWith(src => src.Value);

        config.NewConfig<Guid, ObjectiveActionIndicatorId>().MapWith(src => new ObjectiveActionIndicatorId(src));
        config.NewConfig<ObjectiveActionIndicatorId, Guid>().MapWith(src => src.Value);

        config.NewConfig<ObjectiveActionIndicatorMilestoneId, Guid>().MapWith(src => src.Value);

        config.NewConfig<DateTime, ObjectiveActionIndicatorChangeId>().MapWith(src => new ObjectiveActionIndicatorChangeId(src));
        config.NewConfig<ObjectiveActionIndicatorChangeId, DateTime>().MapWith(src => src.Value);

        config.NewConfig<Objective, ObjectiveBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<Objective, ObjectiveDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Challanges, src => src.Challenges.Select(entity => new ObjectiveChallengeDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(entity => new ObjectiveProjectionDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveDetailQuery, ObjectiveId>().MapWith(src => new ObjectiveId(src.Id));

        config.NewConfig<ObjectiveCreateCommand, Objective>()
            .MapWith(src => new(
                new ObjectiveId(src.Id),
                false,
                true,
                src.Index,
                src.Title,
                src.Challenges.Select(item => new ObjectiveChallenge(new ObjectiveChallengeId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)).ToArray(),
                src.Projections.Select(item => new ObjectiveProjection(new ObjectiveProjectionId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)).ToArray(),
                src.Actions.Select(item => new ObjectiveAction(
                    new(item.Id),
                    new(src.Id),
                    item.Index,
                    item.Title,
                    item.Indicators.Select(_item => new ObjectiveActionIndicator(
                        new(_item.Id),
                        new(item.Id),
                        new(src.Id),
                        _item.Name,
                        new(_item.UnitMeasurement.Id),
                        _item.Priority,
                        _item.Milestones.Select(__item => new ObjectiveActionIndicatorMilestone(
                            new(__item.Id),
                            new(_item.Id),
                            new(item.Id),
                            new(src.Id),
                            __item.At,
                            __item.Amount,
                            __item.Description)),
                        _item.Alias, null)).ToArray(),
                    item.Description)).ToArray(),
                src.Description
            ));

        config.NewConfig<ObjectiveChallengeDetailDto, ObjectiveChallenge>()
            .Map(dest => dest.Id, src => new ObjectiveChallengeId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveChallengeAddonCreateCommand, ObjectiveChallenge>()
            .Map(dest => dest.Id, src => new ObjectiveChallengeId(Guid.NewGuid()))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveProjectionDetailDto, ObjectiveProjection>()
            .Map(dest => dest.Id, src => new ObjectiveProjectionId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveProjectionAddonCreateCommand, ObjectiveProjection>()
            .Map(dest => dest.Id, src => new ObjectiveProjectionId(Guid.NewGuid()))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveActionDetailDto, ObjectiveAction>()
            .Map(dest => dest.Id, src => new ObjectiveActionId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveActionAddonCreateCommand, ObjectiveAction>()
            .Map(dest => dest.Id, src => new ObjectiveActionId(Guid.NewGuid()))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveUpdateCommand, Objective>()
            .Map(dest => dest.Id, src => new ObjectiveId(src.Id))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
            {
                #region Challanges

                foreach (var item in src.InChallenges)
                {
                    ObjectiveChallenge entity = item.Adapt<ObjectiveChallenge>();

                    entity.ObjectiveId = dest.Id;

                    dest.AddChallange(entity);
                }

                foreach (var item in src.OutChallenges)
                {
                    ObjectiveChallenge entity = item.Adapt<ObjectiveChallenge>();

                    entity.ObjectiveId = dest.Id;

                    dest.RemoveChallange(entity);
                }

                foreach (var item in src.PatchChallenges)
                {
                    ObjectiveChallenge target = dest.Challenges.First(entity => entity.Id.Value == item.Id);

                    target.Index = item.Index;
                    target.Title = item.Title;
                    target.Description = item.Description;
                }

                #endregion

                #region Projections

                foreach (var item in src.InProjections)
                {
                    ObjectiveProjection entity = item.Adapt<ObjectiveProjection>();

                    entity.ObjectiveId = dest.Id;

                    dest.AddProjection(entity);
                }

                foreach (var item in src.OutChallenges)
                {
                    ObjectiveProjection entity = item.Adapt<ObjectiveProjection>();

                    entity.ObjectiveId = dest.Id;

                    dest.RemoveProjection(entity);
                }

                foreach (var item in src.PatchProjections)
                {
                    ObjectiveProjection target = dest.Projections.First(entity => entity.Id.Value == item.Id);

                    target.Index = item.Index;
                    target.Title = item.Title;
                    target.Description = item.Description;
                }

                #endregion

                #region Actions

                foreach (var item in src.InActions)
                {
                    ObjectiveActionId actionId = new(item.Id);

                    ObjectiveAction entity = new(
                        actionId,
                        dest.Id,
                        item.Index,
                        item.Title,
                        item.Indicators.Select(item => new ObjectiveActionIndicator(
                            new(item.Id),
                            actionId,
                            dest.Id,
                            item.Name,
                            new(item.UnitMeasurement.Id),
                            item.Priority,
                            item.Milestones.Select(_item => new ObjectiveActionIndicatorMilestone(
                                new(_item.Id),
                                new(item.Id),
                                actionId,
                                dest.Id,
                                _item.At,
                                _item.Amount,
                                _item.Description)),
                            item.Alias)),
                        item.Description);

                    dest.AddAction(entity);
                }

                foreach (var item in src.OutActions)
                {
                    ObjectiveAction entity = item.Adapt<ObjectiveAction>();

                    entity.ObjectiveId = dest.Id;

                    dest.RemoveAction(entity);
                }

                foreach (var item in src.PatchActions)
                {
                    ObjectiveAction entity = dest.Actions.First(_entity => _entity.Id.Value == item.Id && _entity.ObjectiveId == dest.Id);

                    entity.Title = item.Title;
                    entity.Index = item.Index;
                    entity.Description = item.Description;

                    foreach (var _item in item.InIndicators)
                    {
                        ObjectiveActionIndicatorId indicatorId = new(_item.Id);

                        ObjectiveActionIndicator _entity = new(
                            indicatorId,
                            entity.Id,
                            dest.Id,
                            _item.Name,
                            new(_item.UnitMeasurement.Id),
                            _item.Priority,
                            _item.Milestones.Select(__item => new ObjectiveActionIndicatorMilestone(
                                new(__item.Id),
                                indicatorId,
                                entity.Id,
                                dest.Id,
                                __item.At,
                                __item.Amount,
                                __item.Description)),
                            _item.Alias);

                        entity.AddIndicator(_entity);
                    }

                    foreach (var _item in item.OutIndicators)
                    {
                        ObjectiveActionIndicator _entity = _item.Adapt<ObjectiveActionIndicator>();

                        _entity.ActionId = entity.Id;
                        _entity.ObjectiveId = dest.Id;

                        entity.RemoveIndicator(_entity);
                    }

                    foreach (var _item in item.PatchIndicators)
                    {
                        ObjectiveActionIndicator _entity = entity.Indicators.First(_entity => _entity.Id.Value == _item.Id && _entity.ActionId == entity.Id && _entity.ObjectiveId == dest.Id);

                        _entity.Name = _item.Name;
                        _entity.Alias = _item.Alias;

                        if (_entity.UnitMeasurementId.Value != _item.UnitMeasurement.Id)
                        {
                            _entity.UnitMeasurement = null;
                            _entity.UnitMeasurementId = new(_item.UnitMeasurement.Id);
                        }

                        foreach (var __item in _item.InMilestones)
                        {
                            ObjectiveActionIndicatorMilestone __entity = new(new(__item.Id), _entity.Id, entity.Id, dest.Id, __item.At, __item.Amount, __item.Description);

                            _entity.AddMilestone(__entity);
                        }

                        foreach (var __item in _item.OutMilestones)
                        {
                            ObjectiveActionIndicatorMilestone __entity = _item.Adapt<ObjectiveActionIndicatorMilestone>();

                            _entity.RemoveMilestone(_entity.Milestones.First(___entity => ___entity.Id.Value == __item.Id && ___entity.IndicatorId == _entity.Id && ___entity.ActionId == entity.Id && ___entity.ObjectiveId == dest.Id));
                        }

                        foreach (var __item in _item.PatchMilestones)
                        {
                            ObjectiveActionIndicatorMilestone __entity = _entity.Milestones.First(__entity => __entity.Id.Value == __item.Id && __entity.IndicatorId == _entity.Id && __entity.ActionId == entity.Id && __entity.ObjectiveId == dest.Id);

                            __entity.At = __item.At;
                            __entity.Amount = __item.Amount;
                            __entity.Description = __item.Description;
                        }
                    }
                }

                #endregion
            });
    }
}
