using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.DTOs;

public record DocumentBasicDto(Guid Id, string Name, string Extension, long Length) : IDto;