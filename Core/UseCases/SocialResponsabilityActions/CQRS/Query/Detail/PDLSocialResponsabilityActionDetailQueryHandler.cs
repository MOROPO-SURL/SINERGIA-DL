using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Detail;

internal sealed class PDLSocialResponsabilityActionDetailQueryHandler :
    AbstractDetailQueryHandler<PDLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, PDLSocialResponsabilityActionDetailQuery, PDLSocialResponsabilityActionDetailDto>,
    IRequestHandler<PDLSocialResponsabilityActionDetailQuery, PDLSocialResponsabilityActionDetailDto>
{
    public PDLSocialResponsabilityActionDetailQueryHandler(IPDLSocialResponsabilityActionQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}