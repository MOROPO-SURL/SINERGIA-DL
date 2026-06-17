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
        config.NewConfig<Guid, ObjectiveId>()
            .MapWith(src => new ObjectiveId(src));

        config.NewConfig<Objective, ObjectiveBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<Objective, ObjectiveDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Challanges, src => src.Challenges.Select(entity => new ObjectiveChallengeDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(entity => new ObjectiveProjectionDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(entity => new ObjectiveActionDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveDetailQuery, ObjectiveId>()
            .MapWith(src => new ObjectiveId(src.Id));

        config.NewConfig<ObjectiveCreateCommand, Objective>()
            .MapWith(src => new(
                new ObjectiveId(src.Id),
                false,
                true,
                src.Index,
                src.Title,
                src.Challenges.Select(item => new ObjectiveChallenge(new ObjectiveChallengeId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)).ToArray(),
                src.Projections.Select(item => new ObjectiveProjection(new ObjectiveProjectionId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)).ToArray(),
                src.Actions.Select(item => new ObjectiveAction(new ObjectiveActionId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)).ToArray(),
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
                    ObjectiveAction entity = item.Adapt<ObjectiveAction>();

                    entity.ObjectiveId = dest.Id;

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
                    ObjectiveAction target = dest.Actions.First(entity => entity.Id.Value == item.Id);

                    target.Index = item.Index;
                    target.Title = item.Title;
                    target.Description = item.Description;
                }

                #endregion
            });
    }
}
