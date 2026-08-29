using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

public interface ICreateCommand<TDetailDto> : MediatR.IRequest<TDetailDto> where TDetailDto : IDetailDto;