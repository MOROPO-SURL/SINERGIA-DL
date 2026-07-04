using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Update;

public record EconomicActivityUpdateCommand(int Id, bool IsEnabled, bool IsArchived, string Name) : IUpdateCommand<int, EconomicActivityDetailDto>;