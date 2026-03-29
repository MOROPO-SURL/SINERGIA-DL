using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Images.Ports.Repository;

public interface IImageQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Image, ImageId>
{
}