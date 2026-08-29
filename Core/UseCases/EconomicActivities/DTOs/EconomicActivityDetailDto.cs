using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.DTOs;

public record EconomicActivityDetailDto(int Id, string Name, bool IsEnabled, bool IsArchived) : IDetailDto;
