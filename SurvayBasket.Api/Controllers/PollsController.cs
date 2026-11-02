
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurvayBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("GetAll")]
    public ActionResult<List<PollRespones>> GetAll()
    {
        var polls = _pollService.GetAll();
        var respones = polls.Adapt<IEnumerable<PollRespones>>();
        return Ok(respones);
    }

    [HttpGet("{id}")]
    public ActionResult<Poll> GetById([FromRoute]int id)
    {
        var poll = _pollService.GetById(id);
        var respones = poll?.Adapt<PollRespones>();
        return respones is not null ? Ok(respones) : NotFound();
    }

    [HttpPost("")]
    public ActionResult<PollRespones> Add([FromBody]CreatePollRequest createPollRequest)
       
    {   
        var poll = createPollRequest.Adapt<Poll>();
        var addpoll = _pollService.Add(poll);
        return CreatedAtAction(nameof(GetById), new { id = addpoll.Id }, addpoll.Adapt<PollRespones>());
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute]int id, [FromBody] CreatePollRequest createPollRequest)
    {
      var isUpdated = _pollService.Update(id, createPollRequest.Adapt<Poll>());
      return isUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute]int id)
    {
        var isDeleted = _pollService.Delete(id);
        return isDeleted ? NoContent() : NotFound();
    }



}
