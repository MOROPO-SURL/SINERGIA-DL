using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Authentication.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Authentication.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Authentication.DTOs;
using System.Net;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public AuthenticationController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<AuthenticatedSessionDtoModel>> AuthenticateAsync(AuthenticationRequestModel model)
    {
        try
        {
            AuthenticateCommand command = mapper.Map<AuthenticateCommand>(model);

            AuthenticationIdentityDto result = await mediator.Send(command);

            return Ok(mapper.Map<AuthenticatedSessionDtoModel>(result));
        }
        catch (InvalidDataException)
        {
            // User signature validation fail!!
            return Problem(statusCode: (int)HttpStatusCode.ExpectationFailed);
        }
        catch (InvalidOperationException)
        {
            // User disabled!!
            return Problem(statusCode: (int)HttpStatusCode.Locked);
        }
        catch (AccessViolationException)
        {
            // Max authentication failure reached!!
            return Problem(statusCode: (int)HttpStatusCode.Forbidden);
        }
        catch (ArgumentOutOfRangeException)
        {
            // User not found!!
            return Problem(statusCode: (int)HttpStatusCode.Unauthorized);
        }
        catch (UnauthorizedAccessException)
        {
            // Credentials missmatch!!  
            return Problem(statusCode: (int)HttpStatusCode.Unauthorized);
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}
