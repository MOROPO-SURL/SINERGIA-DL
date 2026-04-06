using MapsterMapper;
using MediatR;
using MOROPO.GEDET.CAM.Core.UseCases.Users.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;

internal class PasswordUserUpdateCommandHandler : IRequestHandler<PasswordUserUpdateCommand>
{
    private readonly IUserQueryRepositoryPort userQueryRepository;
    private readonly IUserCommandRepositoryPort userCommandRepository;
    private readonly IDataIntegrityServicePort databaseIntegrityService;
    private readonly IMapper mapper;

    public PasswordUserUpdateCommandHandler(IUserQueryRepositoryPort userQueryRepository, IUserCommandRepositoryPort userCommandRepository, IDataIntegrityServicePort databaseIntegrityService, IMapper mapper)
    {
        this.userQueryRepository = userQueryRepository;
        this.userCommandRepository = userCommandRepository;
        this.databaseIntegrityService = databaseIntegrityService;
        this.mapper = mapper;
    }

    public async Task Handle(PasswordUserUpdateCommand request, CancellationToken cancellationToken)
    {
        User entity = await userQueryRepository.GetAsync(new UserId(request.Id));

        entity = mapper.Map(request, entity);

        entity.Signature = await databaseIntegrityService.GetEntitySignatureAsync(entity);

       await userCommandRepository.UpdateAsync(entity);
    }
}
