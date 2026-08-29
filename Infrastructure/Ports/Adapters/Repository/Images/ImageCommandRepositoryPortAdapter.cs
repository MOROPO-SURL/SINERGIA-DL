using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Images;

internal sealed class ImageCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<Image, ImageId, Guid>, IImageCommandRepositoryPort
{
    public ImageCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}