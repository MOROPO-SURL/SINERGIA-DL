using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Update;

public record EconomicActivityUpdateCommand(int Id, bool IsEnabled, bool IsArchived, string Name) : IUpdateCommand<int, EconomicActivityDetailDto>;