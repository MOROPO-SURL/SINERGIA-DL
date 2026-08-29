using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;

public record ClassificationBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived) : IDto;