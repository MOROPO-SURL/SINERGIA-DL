using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

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
