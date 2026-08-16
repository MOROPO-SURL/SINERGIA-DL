using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Update;

internal sealed class SRLOperationReportUpdateCommandHandler :
    AbstractUpdateCommandHandler<SRLOperationReport, OperationReportId, long, SRLOperationReportUpdateCommand, SRLOperationReportDetailDto>,
    IRequestHandler<SRLOperationReportUpdateCommand, SRLOperationReportDetailDto>
{
    private readonly IDocumentCommandRepositoryPort documentCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;
    private readonly ILogger logger;

    public SRLOperationReportUpdateCommandHandler(ILogger<PDLOperationReportUpdateCommandHandler> logger, IFileStoreServicePort fileStoreService, IDocumentCommandRepositoryPort documentCommandRepository, ISRLOperationReportCommandRepositoryPort entityCommandRepository, ISRLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.fileStoreService = fileStoreService;
        this.documentCommandRepository = documentCommandRepository;
        this.logger = logger;
    }

    protected override async Task<object?> PerformPreUpdateAsync(SRLOperationReportUpdateCommand request, SRLOperationReport entity)
    {
        List<Document> deletedDocuments = [];

        foreach (DocumentCreateCommand model in request.InDocuments)
        {
            DocumentId documentId = new(Guid.NewGuid());
            Document document = new(documentId, model.Name, model.ContentType, model.ContentData.Length);

            await documentCommandRepository.AddAsync(document, false);
            await fileStoreService.SaveFileAsync(documentId.Value.ToString(), model.ContentType, model.ContentData, Constants.FileHandlingConstants.FILE_CATEGORY_DOCUMENT);

            entity.LinkDocumentById(documentId);
        }

        foreach (Guid documentId in request.OutDocumentIds)
        {
            OperationReportDocumentBridge bridge = entity.DocumentBridges.First(bridge => bridge.LinkedId.Value == documentId);

            deletedDocuments.Add(bridge.Linked!);

            await documentCommandRepository.DeleteAsync(bridge.Linked!, false);

            entity.RemoveDocumentBridge(bridge);
        }

        return deletedDocuments.Count > 0 ? deletedDocuments : null;
    }

    protected override Task PerformPostUpdateAsync(SRLOperationReportUpdateCommand request, SRLOperationReport entity, object? context = null)
    {
        if (context is not null && context is List<Document> documents)
        {
            foreach (Document document in documents)
            {
                try
                {
                    fileStoreService.DeleteFile(document.Id.Value.ToString(), document.ContentType);
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