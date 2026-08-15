using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OperationReport.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/pdloperationreports")]
public class PDLOperationReportsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public PDLOperationReportsController(ISender mediator, IMapper mapper, ILogger<PDLOperationReportsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<PDLOperationReportBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<PDLOperationReportBasicDto> result = await mediator.Send(new PDLOperationReportPaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<PDLOperationReportBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<PDLOperationReportBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<PDLOperationReportBasicDto> result = await mediator.Send(new PDLOperationReportPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Owner!.Owner!.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<PDLOperationReportBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("owner/{key}/page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<PDLOperationReportBasicDtoModel>>> FilterByOwnerAsync(Guid key, int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<PDLOperationReportBasicDto> result = await mediator.Send(new PDLOperationReportPaginateQuery(sheet, limit, entity => entity.OwnerId == new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(key)));

            return Ok(mapper.Map<PaginateResultModel<PDLOperationReportBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<PDLOperationReportDetailDtoModel>> GetAsync(long key)
    {
        try
        {
            PDLOperationReportDetailDto result = await mediator.Send(new PDLOperationReportDetailQuery(key));

            return Ok(mapper.Map<PDLOperationReportDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<PDLOperationReportDetailDtoModel>> CreateAsync(PDLOperationReportCreateRequestModel model)
    {
        try
        {
            PDLOperationReportCreateCommand command = mapper.Map<PDLOperationReportCreateCommand>(model);

            PDLOperationReportDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<PDLOperationReportDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<PDLOperationReportDetailDtoModel>> UpdateAsync(PDLOperationReportUpdateRequestModel model)
    {
        try
        {
            PDLOperationReportUpdateCommand command = mapper.Map<PDLOperationReportUpdateCommand>(model);

            PDLOperationReportDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<PDLOperationReportDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}