using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")] //localhost 5029
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var members = context.Users.ToList();
            return members;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetMember(string id)
        { 
            var member = context.Users.Find(id);

            if(member == null) return NotFound();
            return member;
        }
    }
}
 