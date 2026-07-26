using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Update;

internal sealed class SocialSupportDemandUpdateCommandHandler : 
    AbstractUpdateCommandHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandUpdateCommand, SocialSupportDemandDetailDto>,
    IRequestHandler<SocialSupportDemandUpdateCommand, SocialSupportDemandDetailDto>
{
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;
    private readonly ILogger logger;

    public SocialSupportDemandUpdateCommandHandler(ILogger<SocialSupportDemandUpdateCommandHandler> logger, IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, ISocialSupportDemandQueryRepositoryPort entityQueryRepository, ISocialSupportDemandCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.fileStoreService = fileStoreService;
        this.imageCommandRepository = imageCommandRepository;
        this.logger = logger;
    }

    protected override async Task<object?> PerformPreUpdateAsync(SocialSupportDemandUpdateCommand request, SocialSupportDemand entity)
    {
        List<Image> deletedImages = [];

        foreach (LocationClippedCreateCommand model in request.InLocations)
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

            Location location = new(locationId, entity.Id, model.Name, model.PostalAddress.Adapt<PostalAddress>(), model.Coordinate.Adapt<Coordinate>(), imageId, image, model.Description);

            entity.AddLocation(location);
        }

        foreach (Guid locationId in request.OutLocationIds)
        {
            Location location = entity.Locations.First(item => item.Id.Value == locationId);

            if (location.FeatureImage != null)
            {
                deletedImages.Add(location.FeatureImage);

                await imageCommandRepository.DeleteAsync(location.FeatureImage, false);
            }

            entity.RemoveLocation(location);
        }

        foreach(LocationClippedUpdateCommand model in request.PatchLocations)
        {
            Location location = entity.Locations.First(item => item.Id.Value == model.Id);

            location.Name = model.Name;
            location.Coordinate = model.Coordinate.Adapt<Coordinate>();
            location.PostalAddress = model.PostalAddress.Adapt<PostalAddress>();
            location.Description = model.Description;

            if (model.FeatureImageCreateCommand != null)
            {
                Image? currentImage = location.FeatureImage;

                if (currentImage != null) deletedImages.Add(currentImage);

                ImageId imageId = new(Guid.NewGuid());

                Image image = new(imageId, model.FeatureImageCreateCommand.ContentType, model.FeatureImageCreateCommand.ContentData.Length, 0, 0);

                await imageCommandRepository.AddAsync(image, false);

                if (currentImage != null) await imageCommandRepository.DeleteAsync(currentImage, false);

                await fileStoreService.SaveFileAsync(image.Id.Value.ToString(), image.ContentType, model.FeatureImageCreateCommand.ContentData);

                location.FeatureImageId = image.Id;
                location.FeatureImage = image;
            }
        }

        foreach (ImageCreateCommand model in request.InImages)
        {
            ImageId imageId = new(Guid.NewGuid());
            Image image = new(imageId, model.ContentType, model.ContentData.Length, 0, 0);

            await imageCommandRepository.AddAsync(image, false);
            await fileStoreService.SaveFileAsync(imageId.Value.ToString(), model.ContentType, model.ContentData);

            entity.LinkImageById(imageId);
        }

        foreach (Guid imageId in request.OutImageIds)
        {
            SocialSupportDemandImageBridge bridge = entity.ImageBridges.First(bridge => bridge.LinkedId.Value == imageId);

            deletedImages.Add(bridge.Linked!);

            await imageCommandRepository.DeleteAsync(bridge.Linked!, false);

            entity.RemoveImageBridge(bridge);
        }

        return deletedImages.Count > 0 ? deletedImages : null;
    }

    protected override Task PerformPostUpdateAsync(SocialSupportDemandUpdateCommand request, SocialSupportDemand entity, object? context = null)
    {
        if (context is not null && context is List<Image> images)
        {
            foreach (Image image in images)
            {
                try
                {
                    fileStoreService.DeleteFile(image.Id.Value.ToString(), image.ContentType);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }
            }
        }

        return Task.CompletedTask;
    }
}