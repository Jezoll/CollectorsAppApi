namespace CollectorsAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly CollectorsAppDbContext _context;
        public ItemController(CollectorsAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.CollectorsItems.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.CollectorsItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item.CreateItemRequest newItem)
        {
            Item item = new Item();
            item.CollectionId = newItem.CollectionId;
            item.CollectionTypeId = newItem.CollectionTypeId;
            item.Description = newItem.Description;
            item.OwnerId = newItem.OwnerId;
            item.MetaCategory = newItem.MetaCategory;
            item.Attachment = newItem.Attachment;
            
            _context.CollectorsItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.CollectorsItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.CollectorsItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
