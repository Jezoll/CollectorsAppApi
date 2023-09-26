namespace CollectorsAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventController : ControllerBase
    {
        private readonly CollectorsAppDbContext _context;
        public EventController(CollectorsAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Events>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return @event;
        }
        [HttpPost]
        public async Task<ActionResult<Events.AddEventRequest>> PostEvent(Events.AddEventRequest newEvent)
        {
            Events @event = new Events();
            @event.OrganizerId = newEvent.OrganizerId;
            @event.EventAdress = newEvent.EventAdress;
            @event.DateOfEvent = newEvent.DateOfEvent;
            @event.DateOfCreation = newEvent.DateOfCreation;
            @event.ForumTopicId = newEvent.ForumTopicId;
            @event.TookPlace = newEvent.TookPlace;
            @event.Verified = newEvent.Verified;
            @event.AssociatedCollection = newEvent.AssociatedCollection;
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { id = @event.EventId }, @event);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Events @event)
        {
            if (id != @event.EventId)
            {
                return BadRequest();
            }
            _context.Entry(@event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        


    }
}
