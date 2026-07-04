using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;

public record EconomicActivityDetailDto(int Id, string Name, bool IsEnabled, bool IsArchived) : IDetailDto;
