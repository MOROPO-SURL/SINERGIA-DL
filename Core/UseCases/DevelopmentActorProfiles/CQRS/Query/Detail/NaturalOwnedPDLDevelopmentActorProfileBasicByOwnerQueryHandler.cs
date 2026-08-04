using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileBasicByOwnerQueryHandler : IRequestHandler<NaturalOwnedPDLDevelopmentActorProfileBasicByOwnerQuery, DevelopmentActorProfileBasicDto>
{
    private readonly INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public NaturalOwnedPDLDevelopmentActorProfileBasicByOwnerQueryHandler(INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<DevelopmentActorProfileBasicDto> Handle(NaturalOwnedPDLDevelopmentActorProfileBasicByOwnerQuery request, CancellationToken cancellationToken)
    {
        NaturalOwnedPDLDevelopmentActorProfile? entity = await entityQueryRepository.FindOneByAsync(entity => entity.OwnerId == new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(request.OwnerId));

        DevelopmentActorProfileBasicDto dto = mapper.Map<DevelopmentActorProfileBasicDto>(entity!);

        return dto;
    }
}