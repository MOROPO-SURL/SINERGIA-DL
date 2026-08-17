using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Create;

internal sealed class PDLOperationReportCreateCommandHandler :
    AbstractCreateCommandHandler<PDLOperationReport, OperationReportId, long, PDLOperationReportCreateCommand, PDLOperationReportDetailDto>,
    IRequestHandler<PDLOperationReportCreateCommand, PDLOperationReportDetailDto>
{
    private readonly IDocumentCommandRepositoryPort documentCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;

    public PDLOperationReportCreateCommandHandler(IFileStoreServicePort fileStoreService, IDocumentCommandRepositoryPort documentCommandRepository, IPDLOperationReportCommandRepositoryPort entityCommandRepository, IPDLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.fileStoreService = fileStoreService;
        this.documentCommandRepository = documentCommandRepository;
    }

    protected override async Task PerformPreCreateAsync(PDLOperationReportCreateCommand request, PDLOperationReport entity)
    {
        foreach (DocumentCreateCommand model in request.Documents)
        {
            DocumentId documentId = new(Guid.NewGuid());
            Document document = new(documentId, model.Name, model.ContentType, model.ContentData.Length);

            await documentCommandRepository.AddAsync(document, false);
            await fileStoreService.SaveFileAsync(documentId.Value.ToString(), model.ContentType, model.ContentData, Constants.FileHandlingConstants.FILE_CATEGORY_DOCUMENT);

            entity.LinkDocumentById(documentId);
        }
    }
}