namespace CollectorsAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CollectionController : ControllerBase
    {
        private readonly CollectorsAppDbContext _context;
        public CollectionController(CollectorsAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollections()
        {
            return await _context.Collections.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }
            return collection;
        }
        [HttpPost]

        public async Task<ActionResult<Collection>> PostCollection(Collection.AddCollectionRequest newCollection)
        {
            Collection collection = new Collection();
            collection.OwnerId = newCollection.OwnerId;
            collection.CollectionTypeId = newCollection.CollectionTypeId;
            collection.Description = newCollection.Description;
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCollection), new { id = collection.CollectionId }, collection);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, Collection collection)
        {
            if (id != collection.CollectionId)
            {
                return BadRequest();
            }
            _context.Entry(collection).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }
            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
