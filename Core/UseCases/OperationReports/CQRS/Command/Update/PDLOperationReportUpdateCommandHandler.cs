using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Command.Update;

internal sealed class PDLOperationReportUpdateCommandHandler :
    AbstractUpdateCommandHandler<PDLOperationReport, OperationReportId, long, PDLOperationReportUpdateCommand, PDLOperationReportDetailDto>,
    IRequestHandler<PDLOperationReportUpdateCommand, PDLOperationReportDetailDto>
{
    private readonly IDocumentCommandRepositoryPort documentCommandRepository;
    private readonly IFileStoreServicePort fileStoreService;
    private readonly ILogger logger;

    public PDLOperationReportUpdateCommandHandler(ILogger<PDLOperationReportUpdateCommandHandler> logger, IFileStoreServicePort fileStoreService, IDocumentCommandRepositoryPort documentCommandRepository, IPDLOperationReportCommandRepositoryPort entityCommandRepository, IPDLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.fileStoreService = fileStoreService;
        this.documentCommandRepository = documentCommandRepository;
        this.logger = logger;
    }

    protected override async Task<object?> PerformPreUpdateAsync(PDLOperationReportUpdateCommand request, PDLOperationReport entity)
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

    protected override Task PerformPostUpdateAsync(PDLOperationReportUpdateCommand request, PDLOperationReport entity, object? context = null)
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