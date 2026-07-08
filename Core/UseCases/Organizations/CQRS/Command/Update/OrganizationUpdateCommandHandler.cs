using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;

internal sealed class OrganizationUpdateCommandHandler :
    AbstractUpdateCommandHandler<Organization, OrganizationId, Guid, OrganizationUpdateCommand, OrganizationDetailDto>,
    IRequestHandler<OrganizationUpdateCommand, OrganizationDetailDto>
{
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;
    private readonly ILogger logger;

    public OrganizationUpdateCommandHandler(ILogger<OrganizationUpdateCommandHandler> logger, IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, IOrganizationCommandRepositoryPort entityCommandRepository, IOrganizationQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.imageCommandRepository = imageCommandRepository;
        this.fileStoreService = fileStoreService;
        this.logger = logger;
    }

    protected override async Task<Action?> PerformPreUpdateAsync(OrganizationUpdateCommand request, Organization entity)
    {
        Action? postUpdateAction = null;

        if (request.NewImage != null)
        {
            Image? currentImage = entity.Image;

            postUpdateAction = currentImage == null ? null : new Action(() => RemoveOutgoingImage(currentImage));

            ImageId imageId = new(Guid.NewGuid());

            Image image = new(imageId, request.NewImage.ContentType, request.NewImage.ContentData.Length, 0, 0);

            await imageCommandRepository.AddAsync(image, false);

            if (currentImage != null) await imageCommandRepository.DeleteAsync(currentImage, false);

            await fileStoreService.SaveFileAsync(image.Id.Value.ToString(), image.ContentType, request.NewImage.ContentData);

            entity.ImageId = image.Id;
            entity.Image = image;
        }

        return postUpdateAction;
    }

    private void RemoveOutgoingImage(Image entity)
    {
        try
        {
            fileStoreService.DeleteFile(entity.Id.Value.ToString(), entity.ContentType);
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, ex.Message);
        }
    }
}
