namespace SurvayBasket.Api.Services;

public class PollsService : IPollService
{
    private readonly static List<Poll> _polls =
        [

        new Poll { Id = 1, Title = "Poll 1", Description = "Description for Poll 1" },
        new Poll { Id = 2, Title = "Poll 2", Description = "Description for Poll 2" },
        new Poll { Id = 3, Title = "Poll 3", Description = "Description for Poll 3" }

        ];

  

    public IEnumerable<Poll> GetAll() => _polls;

    public Poll? GetById(int id) => _polls.SingleOrDefault(p => p.Id == id);
    public Poll Add(Poll poll)
    {
        poll.Id = _polls.Count + 1;
        _polls.Add(poll);
        return poll;
    }

    public bool Update(int id, Poll poll)
    {
        var CurrentPoll = GetById(id);
        if(CurrentPoll is null)
        {
            return false;
        }
        CurrentPoll.Title = poll.Title;
        CurrentPoll.Description = poll.Description;
        return true;

    }

    public bool Delete(int id)
    {
        var Poll = GetById(id);
        if(Poll is null)
        {
            return false;
        }
        _polls.Remove(Poll);
        return true;
    }
}


