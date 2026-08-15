using Mapster;
using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;

internal sealed class NaturalOwnedPDLDevelopmentActorProfileUpdateCommandHandler :
    AbstractUpdateCommandHandler<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, NaturalOwnedPDLDevelopmentActorProfileUpdateCommand, NaturalOwnedPDLDevelopmentActorProfileDetailDto>,
    IRequestHandler<NaturalOwnedPDLDevelopmentActorProfileUpdateCommand, NaturalOwnedPDLDevelopmentActorProfileDetailDto>
{
    private readonly ILocationCommandRepository locationCommandRepository;
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;

    public NaturalOwnedPDLDevelopmentActorProfileUpdateCommandHandler(IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, ILocationCommandRepository locationCommandRepository, INaturalOwnedPDLDevelopmentActorProfileCommandRepositoryPort entityCommandRepository, INaturalOwnedPDLDevelopmentActorProfileQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.locationCommandRepository = locationCommandRepository;
        this.fileStoreService = fileStoreService;
        this.imageCommandRepository = imageCommandRepository;
    }

    protected override async Task<object?> PerformPreUpdateAsync(NaturalOwnedPDLDevelopmentActorProfileUpdateCommand request, NaturalOwnedPDLDevelopmentActorProfile entity)
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

            if (request.MainLocationId == locationId.Value) continue;

            entity.LinkLocationById(locationId);
        }

        foreach (Guid locationId in request.LinkLocationIds)
        {
            entity.LinkLocationById(new LocationId(locationId));
        }

        foreach (Guid locationId in request.UnlinkLocationIds)
        {
            DevelopmentActorProfileLocationBridge bridge = entity.LocationBridges.First(item => item.LinkedId.Value == locationId);

            //if (bridge.Linked!.FeatureImage != null)
            //{
            //    deletedImages.Add(bridge.Linked.FeatureImage);

            //    await imageCommandRepository.DeleteAsync(bridge.Linked.FeatureImage, false);
            //}

            entity.RemoveLocationBridge(bridge);
        }

        return null;
    }
}