using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;

internal sealed class MacroprogramDetailQueryHandler: AbstractDetailQueryHandler<Macroprogram, MacroprogramId, Guid, MacroprogramDetailQuery, MacroprogramDetailDto>,
    IRequestHandler<MacroprogramDetailQuery, MacroprogramDetailDto>
{
    public MacroprogramDetailQueryHandler(IMacroprogramQueryRepositoryPort macroprogramQueryRepository, IMapper mapper) : base(macroprogramQueryRepository, mapper)
    {
    }
}
