using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.DTOs;

public record DocumentBasicDto(Guid Id, string Name, string Extension, long Length) : IDto;