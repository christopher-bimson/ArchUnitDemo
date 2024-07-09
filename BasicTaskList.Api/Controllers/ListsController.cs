using BasicTaskList.Api.Model.ApplicationServices;
using BasicTaskList.Api.Model.Core;
using BasicTaskList.Api.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BasicTaskList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ListsController : ControllerBase
{
    private readonly ILogger<ListsController> logger;
    private readonly ListApplicationService listApplicationService;

    public ListsController(ILogger<ListsController> logger,
        ListApplicationService listApplicationService)
    {
        this.logger = logger;
        this.listApplicationService = listApplicationService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(ListResource request)
    {
        var readModel = await listApplicationService.Create(request.Name, request.Tasks
            .Select(r => r.Text));

        var resource = ListResource.From(readModel);
        var uri = Url.Action("Get", new { id = resource.Id });
        
        return Created(uri, resource);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        var maybeReadModel = await listApplicationService.GetById(id);
        
        IActionResult result = NotFound();
        maybeReadModel.MatchSome(rm => result = Ok(ListResource.From(rm)));
        
        return result;
    }
}