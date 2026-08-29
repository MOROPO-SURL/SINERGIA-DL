using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;

public record EconomicActivityBasicDto(int Id, string Name, bool IsEnabled, bool IsArchived) : IDto;