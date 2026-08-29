using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Update;

internal sealed class PersonUpdateCommandHandler :
    AbstractUpdateCommandHandler<Person, PersonId, Guid, PersonUpdateCommand, PersonDetailDto>,
    IRequestHandler<PersonUpdateCommand, PersonDetailDto>
{
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;
    private readonly ILogger logger;

    public PersonUpdateCommandHandler(ILogger<PersonUpdateCommandHandler> logger, IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, IPersonCommandRepositoryPort entityCommandRepository, IPersonQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.imageCommandRepository = imageCommandRepository;
        this.fileStoreService = fileStoreService;
        this.logger = logger;
    }

    protected override async Task<object?> PerformPreUpdateAsync(PersonUpdateCommand request, Person entity)
    {
        object? postUpdateContext = null;

        if (request.NewImage != null)
        {
            Image? currentImage = entity.Image;

            postUpdateContext = currentImage;

            ImageId imageId = new(Guid.NewGuid());

            Image image = new(imageId, request.NewImage.ContentType, request.NewImage.ContentData.Length, 0, 0);

            await imageCommandRepository.AddAsync(image, false);

            if (currentImage != null) await imageCommandRepository.DeleteAsync(currentImage, false);

            await fileStoreService.SaveFileAsync(image.Id.Value.ToString(), image.ContentType, request.NewImage.ContentData);

            entity.ImageId = image.Id;
            entity.Image = image;
        }

        return postUpdateContext;
    }

    protected override Task PerformPostUpdateAsync(PersonUpdateCommand request, Person entity, object? context = null)
    {
        if (context is not null && context is Image image)
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

        return Task.CompletedTask;
    }
}
