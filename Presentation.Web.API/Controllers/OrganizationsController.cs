using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers
{
    [ApiController]
    [Route("api/organizations")]
    public class OrganizationsController: ControllerBase
    {
        private readonly ISender mediator;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public OrganizationsController(ISender mediator, IMapper mapper, ILogger<OrganizationsController> logger)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [Route("page/{sheet}/limit/{limit}")]
        public async Task<ActionResult<PaginateResultModel<OrganizationBasicDtoModel>>> GetAsync(int sheet, int limit)
        {
            try
            {
                PaginateQueryResultModel<OrganizationBasicDto> result = await mediator.Send(new OrganizationPaginateQuery(sheet, limit, entity => !entity.IsArchived));

                return Ok(mapper.Map<PaginateResultModel<OrganizationBasicDtoModel>>(result));
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpGet]
        [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
        public async Task<ActionResult<PaginateResultModel<OrganizationBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
        {
            try
            {
                PaginateQueryResultModel<OrganizationBasicDto> result = await mediator.Send(new OrganizationPaginateQuery(
                    sheet,
                    limit,
                    entity => !entity.IsArchived && EF.Functions.ILike(entity.Name, $"%{parameter}%")));

                return Ok(mapper.Map<PaginateResultModel<OrganizationBasicDtoModel>>(result));
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<OrganizationDetailDtoModel>> GetAsync(Guid key)
        {
            try
            {
                OrganizationDetailDto result = await mediator.Send(new OrganizationDetailQuery(key));

                return Ok(mapper.Map<OrganizationDetailDtoModel>(result));
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrganizationDetailDtoModel>> CreateAsync(OrganizationCreateRequestModel model)
        {
            try
            {
                OrganizationCreateCommand command = mapper.Map<OrganizationCreateCommand>(model);

                OrganizationDetailDto result = await mediator.Send(command);

                return Ok(mapper.Map<OrganizationDetailDtoModel>(result));
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrganizationDetailDtoModel>> UpdateAsync(OrganizationUpdateRequestModel model)
        {
            try
            {
                OrganizationUpdateCommand command = mapper.Map<OrganizationUpdateCommand>(model);

                OrganizationDetailDto result = await mediator.Send(command);

                return Ok(mapper.Map<OrganizationDetailDtoModel>(result));
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpPatch("{key}/enable")]
        public async Task<IActionResult> EnableAsync(Guid key)
        {
            try
            {
                await mediator.Send(new OrganizationEnableCommand(key));

                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpPatch("{key}/disable")]
        public async Task<IActionResult> DisableAsync(Guid key)
        {
            try
            {
                await mediator.Send(new OrganizationDisableCommand(key));

                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpPatch("{key}/unarchive")]
        public async Task<IActionResult> UnarchiveAsync(Guid key)
        {
            try
            {
                await mediator.Send(new OrganizationUnarchiveCommand(key));

                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpPatch("{key}/archive")]
        public async Task<IActionResult> ArchiveAsync(Guid key)
        {
            try
            {
                await mediator.Send(new OrganizationArchiveCommand(key));

                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteAsync(Guid key)
        {
            try
            {
                await mediator.Send(new OrganizationRemoveCommand(key));

                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                return Problem();
            }
        }
    }
}
