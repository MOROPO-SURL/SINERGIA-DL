using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileDetailByOwnerQueryHandler : IRequestHandler<NaturalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery, NaturalOwnedPDLDevelopmentActorProfileDetailDto>
{
    private readonly INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public NaturalOwnedPDLDevelopmentActorProfileDetailByOwnerQueryHandler(INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<NaturalOwnedPDLDevelopmentActorProfileDetailDto> Handle(NaturalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery request, CancellationToken cancellationToken)
    {
        NaturalOwnedPDLDevelopmentActorProfile? entity = await entityQueryRepository.FindOneByAsync(entity => entity.OwnerId == new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(request.OwnerId));

        NaturalOwnedPDLDevelopmentActorProfileDetailDto dto = mapper.Map<NaturalOwnedPDLDevelopmentActorProfileDetailDto>(entity!);

        return dto;
    }
}