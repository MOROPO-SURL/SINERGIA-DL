using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;

public record EconomicActivityBasicDto(int Id, string Name, bool IsEnabled, bool IsArchived) : IDto;