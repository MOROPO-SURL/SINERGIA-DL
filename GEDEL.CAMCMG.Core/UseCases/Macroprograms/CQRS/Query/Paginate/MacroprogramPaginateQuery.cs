using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using System.Linq.Expressions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Paginate;

public record MacroprogramPaginateQuery(int Page, int Limit, Expression<Func<Macroprogram, bool>>? Criteria = null) : IPaginateQuery<Macroprogram, MacroprogramId, Guid, MacroprogramBasicDto>;

