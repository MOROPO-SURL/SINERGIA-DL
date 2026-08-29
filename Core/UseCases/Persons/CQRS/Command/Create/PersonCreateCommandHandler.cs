using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Images.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Create;

internal sealed class PersonCreateCommandHandler :
    AbstractCreateCommandHandler<Person, PersonId, Guid, PersonCreateCommand, PersonDetailDto>,
    IRequestHandler<PersonCreateCommand, PersonDetailDto>
{
    private readonly IImageCommandRepositoryPort imageCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;

    public PersonCreateCommandHandler(IFileStoreServicePort fileStoreService, IImageCommandRepositoryPort imageCommandRepository, IPersonCommandRepositoryPort entityCommandRepository, IPersonQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.imageCommandRepository = imageCommandRepository;
        this.fileStoreService = fileStoreService;
    }

    protected override async Task PerformPreCreateAsync(PersonCreateCommand request, Person entity)
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
