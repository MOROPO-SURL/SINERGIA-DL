using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Update;

internal sealed class SRLSocialResponsabilityActionUpdateCommandHandler :
    AbstractUpdateCommandHandler<SRLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, SRLSocialResponsabilityActionUpdateCommand, SRLSocialResponsabilityActionDetailDto>,
    IRequestHandler<SRLSocialResponsabilityActionUpdateCommand, SRLSocialResponsabilityActionDetailDto>
{
    private readonly ILocationCommandRepository locationCommandRepository;
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;
    private readonly ILogger logger;

    public SRLSocialResponsabilityActionUpdateCommandHandler(ILogger<SRLSocialResponsabilityActionUpdateCommandHandler> logger, IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, ILocationCommandRepository locationCommandRepository, ISRLSocialResponsabilityActionCommandRepositoryPort entityCommandRepository, ISRLSocialResponsabilityActionQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.locationCommandRepository = locationCommandRepository;
        this.fileStoreService = fileStoreService;
        this.imageCommandRepository = imageCommandRepository;
        this.logger = logger;
    }

    protected override async Task<object?> PerformPreUpdateAsync(SRLSocialResponsabilityActionUpdateCommand request, SRLSocialResponsabilityAction entity)
    {
        List<Image> deletedImages = [];

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

        foreach (Guid locationId in request.UnlinkLocationIds)
        {
            SocialResponsabilityActionLocationBridge bridge = entity.LocationBridges.First(item => item.LinkedId.Value == locationId);

            entity.RemoveLocationBridge(bridge);
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
            SocialResponsabilityActionImageBridge bridge = entity.ImageBridges.First(bridge => bridge.LinkedId.Value == imageId);

            deletedImages.Add(bridge.Linked!);

            await imageCommandRepository.DeleteAsync(bridge.Linked!, false);

            entity.RemoveImageBridge(bridge);
        }

        return deletedImages.Count > 0 ? deletedImages : null;
    }

    protected override Task PerformPostUpdateAsync(SRLSocialResponsabilityActionUpdateCommand request, SRLSocialResponsabilityAction entity, object? context = null)
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