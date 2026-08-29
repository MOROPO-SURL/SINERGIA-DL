using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;

internal sealed class MacroprogramDetailQueryHandler: AbstractDetailQueryHandler<Macroprogram, MacroprogramId, Guid, MacroprogramDetailQuery, MacroprogramDetailDto>,
    IRequestHandler<MacroprogramDetailQuery, MacroprogramDetailDto>
{
    public MacroprogramDetailQueryHandler(IMacroprogramQueryRepositoryPort macroprogramQueryRepository, IMapper mapper) : base(macroprogramQueryRepository, mapper)
    {
    }
}
