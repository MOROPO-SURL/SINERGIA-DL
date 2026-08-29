using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.OperationReport.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/srloperationreports")]
public class SRLOperationReportsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public SRLOperationReportsController(ISender mediator, IMapper mapper, ILogger<SRLOperationReportsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<SRLOperationReportBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<SRLOperationReportBasicDto> result = await mediator.Send(new SRLOperationReportPaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<SRLOperationReportBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<SRLOperationReportBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<SRLOperationReportBasicDto> result = await mediator.Send(new SRLOperationReportPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Owner!.Owner!.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<SRLOperationReportBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("owner/{key}/page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<SRLOperationReportBasicDtoModel>>> FilterByOwnerAsync(Guid key, int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<SRLOperationReportBasicDto> result = await mediator.Send(new SRLOperationReportPaginateQuery(sheet, limit, entity => entity.OwnerId == new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(key)));

            return Ok(mapper.Map<PaginateResultModel<SRLOperationReportBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<SRLOperationReportDetailDtoModel>> GetAsync(long key)
    {
        try
        {
            SRLOperationReportDetailDto result = await mediator.Send(new SRLOperationReportDetailQuery(key));

            return Ok(mapper.Map<SRLOperationReportDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<SRLOperationReportDetailDtoModel>> CreateAsync(SRLOperationReportCreateRequestModel model)
    {
        try
        {
            SRLOperationReportCreateCommand command = mapper.Map<SRLOperationReportCreateCommand>(model);

            SRLOperationReportDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SRLOperationReportDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<SRLOperationReportDetailDtoModel>> UpdateAsync(SRLOperationReportUpdateRequestModel model)
    {
        try
        {
            SRLOperationReportUpdateCommand command = mapper.Map<SRLOperationReportUpdateCommand>(model);

            SRLOperationReportDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SRLOperationReportDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}