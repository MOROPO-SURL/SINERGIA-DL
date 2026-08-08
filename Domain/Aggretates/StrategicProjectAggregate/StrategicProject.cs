using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using System;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;

public class StrategicProject : AbstractAuditableEntity<StrategicProjectId, Guid>, IAggregateRoot<StrategicProjectId, Guid>, INamedEntity<StrategicProjectId, Guid>, IArchivableEntity<StrategicProjectId, Guid>, IEnableableEntity<StrategicProjectId, Guid>, IPriorizableEntity<StrategicProjectId, Guid>
{
    private readonly List<ProjectSpecificObjective> specificObjectives = [];
    private readonly List<ProjectIndicator> indicators = [];
    private readonly List<StrategicProjectMacroprogramBridge> macroprogramBridges = [];

    private StrategicProject() : base(new StrategicProjectId(default)) { }

    public StrategicProject(
        StrategicProjectId id, 
        StrategicProjectKindId kindId, 
        StrategicProgramId programId, 
        bool isEnabled, 
        bool isArchived, 
        string name, 
        string objective, 
        int priority, 
        IEnumerable<ProjectSpecificObjective> specificObjectives,
        IEnumerable<ProjectIndicator> indicators,
        IEnumerable<StrategicProjectMacroprogramBridge> macroprogramBridges,
        string? description = null,
        StrategicProjectKind? kind = null, 
        StrategicProgram? program = null) : base(id)
    {
        KindId = kindId;
        ProgramId = programId;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        Objective = objective; 
        Description = description;
        Priority = priority;
        Kind = kind;
        Program = program;
        this.specificObjectives = [.. specificObjectives];
        this.indicators = [.. indicators];
        this.macroprogramBridges = [.. macroprogramBridges];
    }

    public StrategicProjectKindId KindId { get; set; }
    public StrategicProjectKind? Kind { get; set; }

    public StrategicProgramId ProgramId { get; set; }
    public StrategicProgram? Program { get; set; }

    // TODO Incluir otros programas

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public int Priority { get; set; }

    public string Name { get; set; } = null!;

    public string Objective { get; set; } = null!;


    public IReadOnlyList<ProjectSpecificObjective> SpecificObjectives => [.. specificObjectives];

    public IReadOnlyList<ProjectIndicator> Indicators => [.. indicators];

    public IReadOnlyList<StrategicProjectMacroprogramBridge> MacroprogramBridges => [.. macroprogramBridges];

    public void AddSpecificObjective(ProjectSpecificObjective entity)
    {
        specificObjectives.Add(entity);
    }

    public void RemoveSpecificObjective(ProjectSpecificObjective entity)
    {
        specificObjectives.Remove(specificObjectives.First(_entity => _entity.Id == entity.Id));
    }

    public void AddIndicator(ProjectIndicator entity)
    {
        indicators.Add(entity);
    }

    public void RemoveIndicator(ProjectIndicator entity)
    {
        indicators.Remove(indicators.First(_entity => _entity.Id == entity.Id && _entity.ProjectId == entity.ProjectId));
    }

    public void LinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Add(new StrategicProjectMacroprogramBridge(Id, macroprogramId));

    public void UnlinkMacroprogramById(MacroprogramId macroprogramId) => macroprogramBridges.Remove(macroprogramBridges.First(bridge => bridge.LinkedId == macroprogramId));

    public string? Description { get; set; }
}
