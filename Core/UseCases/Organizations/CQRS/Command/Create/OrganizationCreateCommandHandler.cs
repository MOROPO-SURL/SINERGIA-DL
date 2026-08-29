using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Create;

internal sealed class OrganizationCreateCommandHandler :
    AbstractCreateCommandHandler<Organization, OrganizationId, Guid, OrganizationCreateCommand, OrganizationDetailDto>,
    IRequestHandler<OrganizationCreateCommand, OrganizationDetailDto>
{
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;

    public OrganizationCreateCommandHandler(IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, IOrganizationCommandRepositoryPort entityCommandRepository, IOrganizationQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.imageCommandRepository = imageCommandRepository;
        this.fileStoreService = fileStoreService;
    }

    protected override async Task PerformPreCreateAsync(OrganizationCreateCommand request, Organization entity)
    {
        if (request.NewImage != null)
        {
            ImageId imageId = new(Guid.NewGuid());

            Image image = new(imageId, request.NewImage.ContentType, request.NewImage.ContentData.Length, 0, 0);

            await imageCommandRepository.AddAsync(image, false);

            await fileStoreService.SaveFileAsync(imageId.Value.ToString(), request.NewImage.ContentType, request.NewImage.ContentData);

            entity.ImageId = image.Id;
            entity.Image = image;
        }
    }
}
