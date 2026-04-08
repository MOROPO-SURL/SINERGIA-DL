using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

public interface ICreateCommand<TDetailDto> : MediatR.IRequest<TDetailDto> where TDetailDto : IDetailDto;