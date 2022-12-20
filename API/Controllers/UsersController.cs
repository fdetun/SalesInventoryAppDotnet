using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController
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