
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{   

    public class UsersController: BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext ctxt)
        {
                    _context = ctxt;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
         {
            var users =  _context.Users.ToList();
            return users;
         }


        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUserById(int id)
         {
            var user =  _context.Users.Find(id);
            return user;
         }

         [HttpGet("~/asyncbyid/{id}")]
        public async Task<ActionResult<AppUser>> GetUserByIdAsync(int id)
         {
            var user =  await _context.Users.FindAsync(id);
            return user;
         }
    }
}