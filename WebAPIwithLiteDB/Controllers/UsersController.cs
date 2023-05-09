using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIwithLiteDB.LiteDb;
using WebAPIwithLiteDB.Models;

namespace WebAPIwithLiteDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private LiteDatabase _liteDb;

        public UsersController(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = _liteDb.GetCollection<User>("users").FindAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(User user)
        {
            _liteDb.GetCollection<User>("users")
                .Insert(user);
            return Ok();
        }
    }
}
