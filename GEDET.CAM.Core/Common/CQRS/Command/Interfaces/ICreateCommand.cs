using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;

public interface ICreateCommand<TDetailDto> : MediatR.IRequest<TDetailDto> where TDetailDto : IDetailDto;