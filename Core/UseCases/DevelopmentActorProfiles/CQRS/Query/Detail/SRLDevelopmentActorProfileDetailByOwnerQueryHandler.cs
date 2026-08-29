using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class SRLDevelopmentActorProfileDetailByOwnerQueryHandler : IRequestHandler<SRLDevelopmentActorProfileDetailByOwnerQuery, SRLDevelopmentActorProfileDetailDto>
{
    private readonly ISRLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public SRLDevelopmentActorProfileDetailByOwnerQueryHandler(ISRLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<SRLDevelopmentActorProfileDetailDto> Handle(SRLDevelopmentActorProfileDetailByOwnerQuery request, CancellationToken cancellationToken)
    {
        SRLDevelopmentActorProfile? entity = await entityQueryRepository.FindOneByAsync(entity => entity.OwnerId == new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(request.OwnerId));

        SRLDevelopmentActorProfileDetailDto dto = mapper.Map<SRLDevelopmentActorProfileDetailDto>(entity!);

        return dto;
    }
}
