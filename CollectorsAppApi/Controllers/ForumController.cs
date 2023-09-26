namespace CollectorsAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ForumController : ControllerBase
    {
        private readonly CollectorsAppDbContext _context;
        public ForumController(CollectorsAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumTopic>>> GetForumTopics()
        {
            return await _context.ForumTopics.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ForumTopic>> GetForumTopic(int id)
        {
            var forumTopic = await _context.ForumTopics.FindAsync(id);
            if (forumTopic == null)
            {
                return NotFound();
            }
            return forumTopic;
        }
        [HttpPost]
        public async Task<ActionResult<ForumTopic>> PostForumTopic(ForumTopic.AddForumTopicRequest newForumTopic)
        {
            ForumTopic forumTopic = new ForumTopic();
            forumTopic.TopicName = newForumTopic.TopicName;
            forumTopic.Active = newForumTopic.Active;
            forumTopic.AssociatedCollection = newForumTopic.AssociatedCollection;
            forumTopic.CreatorId = newForumTopic.CreatorId;
            _context.ForumTopics.Add(forumTopic);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetForumTopic), new { id = forumTopic.TopicId }, forumTopic);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForumTopic(int id, ForumTopic forumTopic)
        {
            if (id != forumTopic.TopicId)
            {
                return BadRequest();
            }
            _context.Entry(forumTopic).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForumTopic(int id)
        {
            var forumTopic = await _context.ForumTopics.FindAsync(id);
            if (forumTopic == null)
            {
                return NotFound();
            }
            _context.ForumTopics.Remove(forumTopic);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("{TopicID}")]
        public async Task<ActionResult<IEnumerable<ForumPost>>> GetForumPosts(int TopicID)
        {
            return await _context.ForumPosts.Where(x => x.TopicId == TopicID).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<ForumPost>> PostForumPost(ForumPost.AddForumPostRequest newForumPost)
        {
            ForumPost forumPost = new ForumPost();
            forumPost.TopicId = newForumPost.TopicId;
            forumPost.PostBody = newForumPost.PostBody;
            forumPost.CreatorId = newForumPost.CreatorId;
            _context.ForumPosts.Add(forumPost);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetForumPosts), new { id = forumPost.PostId }, forumPost);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForumPost(int id, ForumPost forumPost)
        {
            if (id != forumPost.PostId)
            {
                return BadRequest();
            }
            _context.Entry(forumPost).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForumPost(int id)
        {
            var forumPost = await _context.ForumPosts.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }
            _context.ForumPosts.Remove(forumPost);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
