using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class LegalOwnedPDLDevelopmentActorProfileDetailByOwnerQueryHandler : IRequestHandler<LegalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery, LegalOwnedPDLDevelopmentActorProfileDetailDto>
{
    private readonly ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public LegalOwnedPDLDevelopmentActorProfileDetailByOwnerQueryHandler(ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<LegalOwnedPDLDevelopmentActorProfileDetailDto> Handle(LegalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery request, CancellationToken cancellationToken)
    {
        LegalOwnedPDLDevelopmentActorProfile? entity = await entityQueryRepository.FindOneByAsync(entity => entity.OwnerId == new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(request.OwnerId));

        LegalOwnedPDLDevelopmentActorProfileDetailDto dto = mapper.Map<LegalOwnedPDLDevelopmentActorProfileDetailDto>(entity!);

        return dto;
    }
}