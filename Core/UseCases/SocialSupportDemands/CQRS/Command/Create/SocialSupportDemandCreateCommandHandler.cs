using Mapster;
using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create;

internal sealed class SocialSupportDemandCreateCommandHandler : 
    AbstractCreateCommandHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandCreateCommand, SocialSupportDemandDetailDto>,
    IRequestHandler<SocialSupportDemandCreateCommand, SocialSupportDemandDetailDto>
{
    private readonly ILocationCommandRepository locationCommandRepository;
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;

    public SocialSupportDemandCreateCommandHandler(IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, ILocationCommandRepository locationCommandRepository, ISocialSupportDemandCommandRepositoryPort entityCommandRepository, ISocialSupportDemandQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.locationCommandRepository = locationCommandRepository;
        this.fileStoreService = fileStoreService;
        this.imageCommandRepository = imageCommandRepository;
    }

    protected override async Task PerformPreCreateAsync(SocialSupportDemandCreateCommand request, SocialSupportDemand entity)
    {
        foreach (LocationCreateCommand model in request.InLocations)
        {
            LocationId locationId = new(model.Id);

            ImageId? imageId = null;
            Image? image = null;

            if (model.FeatureImageCreateCommand != null)
            {
                imageId = new(Guid.NewGuid());
                image = new(imageId.Value, model.FeatureImageCreateCommand.ContentType, model.FeatureImageCreateCommand.ContentData.Length, 0, 0);

                await imageCommandRepository.AddAsync(image, false);
                await fileStoreService.SaveFileAsync(imageId.Value.ToString(), model.FeatureImageCreateCommand.ContentType, model.FeatureImageCreateCommand.ContentData);
            }

            await locationCommandRepository.AddAsync(
                new(locationId, model.Name, model.PostalAddress.Adapt<PostalAddress>(), model.Coordinate.Adapt<Coordinate>(), imageId, image, model.Description),
                false);

            entity.LinkLocationById(locationId);
        }

        foreach (Guid locationId in request.LinkLocationIds)
        {
            entity.LinkLocationById(new LocationId(locationId));
        }

        foreach (ImageCreateCommand model in request.Images)
        {
            ImageId imageId = new(Guid.NewGuid());
            Image image = new(imageId, model.ContentType, model.ContentData.Length, 0, 0);

            await imageCommandRepository.AddAsync(image, false);
            await fileStoreService.SaveFileAsync(imageId.Value.ToString(), model.ContentType, model.ContentData);

            entity.LinkImageById(imageId);
        }
    }
}