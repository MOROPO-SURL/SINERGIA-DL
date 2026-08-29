using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Update;

internal class EssentialUserUpdateCommandHandler : MediatR.IRequestHandler<EssentialUserUpdateCommand, UserDetailDto>
{
    private readonly IUserQueryRepositoryPort userQueryRepository;
    private readonly IUserCommandRepositoryPort userCommandRepository;
    private readonly IMapper mapper;

    public EssentialUserUpdateCommandHandler(IUserQueryRepositoryPort userQueryRepository, IUserCommandRepositoryPort userCommandRepository, IMapper mapper)
    {
        this.userQueryRepository = userQueryRepository;
        this.userCommandRepository = userCommandRepository;
        this.mapper = mapper;
    }

    public async Task<UserDetailDto> Handle(EssentialUserUpdateCommand request, CancellationToken cancellationToken)
    {
        User entity = await userQueryRepository.GetAsync(new UserId(request.Id));

        entity = mapper.Map(request, entity);

        await userCommandRepository.UpdateAsync(entity);

        return mapper.Map<User, UserDetailDto>(await userQueryRepository.GetAsync(new UserId(request.Id)));
    }
}
