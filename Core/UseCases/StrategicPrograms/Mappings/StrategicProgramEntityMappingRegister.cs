using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
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

        config.NewConfig<StrategicProgram, StrategicProgramBasicDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgram, StrategicProgramDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
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
                Array.Empty<ProgramAction>(), //src.Actions.Select(item => new ProgramAction(new ProgramActionId(item.Id), new StrategicProgramId(src.Id), item.Title, item.Priority, Array.Empty<ProgramActionInterestAreaBridge>(), item.Description)).ToArray(),
                Array.Empty<ProgramProjectIdea>(),
                src.Organizations.Select(item => new StrategicProgramOrganizationBridge(new StrategicProgramId(src.Id), new OrganizationId(item.Id), null)).ToArray(),
                src.Macroprograms.Select(item => new StrategicProgramMacroprogramBridge(new StrategicProgramId(src.Id), new MacroprogramId(item.Id), null)).ToArray(),
                null,
                null,
                src.Description
            ));

        config.NewConfig<ProgramObjectiveAddonCreateCommand, ProgramObjective>()
            .Map(dest => dest.Id, src => new ProgramObjectiveId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ProgramObjectiveDetailDto, ProgramObjective>()
            .Map(dest => dest.Id, src => new ProgramObjectiveId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ProgramActionAddonCreateCommand, ProgramAction>()
            .Map(dest => dest.Id, src => new ProgramActionId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<ProgramActionDetailDto, ProgramAction>()
            .Map(dest => dest.Id, src => new ProgramActionId(src.Id))
            .Map(dest => dest, src => src);

        config.NewConfig<StrategicProgramUpdateCommand, StrategicProgram>()
            .Map(dest => dest.Id, src => new StrategicProgramId(src.Id))
            .Map(dest => dest, src => src)
            .AfterMapping((src, dest) =>
            {
                //#region Objectives

                //foreach (var item in src.InObjectives)
                //{
                //    ProgramObjective entity = item.Adapt<ProgramObjective>();

                //    entity.StrategicProgramId = dest.Id;

                //    dest.AddObjective(entity);
                //}

                //foreach (var item in src.OutObjectives)
                //{
                //    ProgramObjective entity = item.Adapt<ProgramObjective>();

                //    entity.StrategicProgramId = dest.Id;

                //    dest.RemoveObjective(entity);
                //}

                //foreach (var item in src.PatchObjectives)
                //{
                //    ProgramObjective target = dest.Objetives.First(entity => entity.Id.Value == item.Id);

                //    target.Name = item.Name;
                //    target.IsEnabled = item.IsEnabled;
                //    target.Description = item.Description;
                //}

                //#endregion

                //#region Actions

                //foreach (var item in src.InActions)
                //{
                //    ProgramAction entity = item.Adapt<ProgramAction>();

                //    entity.StrategicProgramId = dest.Id;

                //    dest.AddAction(entity);
                //}

                //foreach (var item in src.OutActions)
                //{
                //    ProgramAction entity = item.Adapt<ProgramAction>();

                //    entity.StrategicProgramId = dest.Id;

                //    dest.RemoveAction(entity);
                //}

                //foreach (var item in src.PatchActions)
                //{
                //    ProgramAction target = dest.Actions.First(entity => entity.Id.Value == item.Id);

                //    target.Title = item.Title;
                //    target.Priority = item.Priority;
                //    target.Description = item.Description;
                //}

                //#endregion

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