using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class SRLDevelopmentActorProfileBasicByOwnerQueryHandler : IRequestHandler<SRLDevelopmentActorProfileBasicByOwnerQuery, DevelopmentActorProfileBasicDto>
{
    private readonly ISRLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public SRLDevelopmentActorProfileBasicByOwnerQueryHandler(ISRLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<DevelopmentActorProfileBasicDto> Handle(SRLDevelopmentActorProfileBasicByOwnerQuery request, CancellationToken cancellationToken)
    {
        SRLDevelopmentActorProfile? entity = await entityQueryRepository.FindOneByAsync(entity => entity.OwnerId == new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(request.OwnerId));

        DevelopmentActorProfileBasicDto dto = mapper.Map<DevelopmentActorProfileBasicDto>(entity!);

        return dto;
    }
}
