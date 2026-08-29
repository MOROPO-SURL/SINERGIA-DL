using Mapster;
using MapsterMapper;
using MediatR;
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
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Create;

internal sealed class SRLSocialResponsabilityActionCreateCommandHandler :
    AbstractCreateCommandHandler<SRLSocialResponsabilityAction, SocialResponsabilityActionId, Guid, SRLSocialResponsabilityActionCreateCommand, SRLSocialResponsabilityActionDetailDto>,
    IRequestHandler<SRLSocialResponsabilityActionCreateCommand, SRLSocialResponsabilityActionDetailDto>
{
    private readonly ILocationCommandRepository locationCommandRepository;
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;

    public SRLSocialResponsabilityActionCreateCommandHandler(IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, ILocationCommandRepository locationCommandRepository, ISRLSocialResponsabilityActionCommandRepositoryPort entityCommandRepository, ISRLSocialResponsabilityActionQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.locationCommandRepository = locationCommandRepository;
        this.fileStoreService = fileStoreService;
        this.imageCommandRepository = imageCommandRepository;
    }

    protected override async Task PerformPreCreateAsync(SRLSocialResponsabilityActionCreateCommand request, SRLSocialResponsabilityAction entity)
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