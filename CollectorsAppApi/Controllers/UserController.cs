using Org.BouncyCastle.Crypto.Generators;

namespace CollectorsAppApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CollectorsAppDbContext _context;
        public UserController(CollectorsAppDbContext context)
        {
            _context = context;
        }   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User.ViewUserResponse>> GetUser(int id)
        {
            var user = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            User.ViewUserResponse response = new User.ViewUserResponse();
            response.UserId = user.UserId;
            response.Login = user.Login;
            response.Email = user.Email;
            response.Admin = user.Admin;
            if (user == null)
            {
                return NotFound();
            }
            return response;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User.AddUserRequest newUser)
        {
            User user = new User();
            user.Login = newUser.Login;
            user.PasswordHash = BCrypt.PasswordToByteArray(newUser.Password.ToCharArray());
            user.Email = newUser.Email;
            user.Admin = newUser.Admin;
            user.UserImage = newUser.UserImage;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
