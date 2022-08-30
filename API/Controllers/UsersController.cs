using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Common;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("getallusers")]
        public async Task<ActionResult<Responses>> GetUsers()
        {
            if (_context.Users == null)
            {
                return Responses.Failure("No User Found");
            }
            var users = await _context.Users.ToListAsync();
            if (users != null)
                return Responses.Success("Users found", users);
            else
                return Responses.Failure("There are no users in the database");
        }

        // GET: api/Users/5
        [HttpGet("getuserbyid/{id}")]
        public async Task<Responses> GetUser(int id)
        {
            try
            {
                if (_context.Users == null)
                {
                    return Responses.Failure("There are no users in the database");
                }                
                var findUser = _context.Users.Where(p => p.Id == id).FirstOrDefault();
                if (findUser != null)
                {
                    return Responses.Success("User found", findUser);
                }
                else
                    return Responses.Failure($"User with userid {id} not found");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createuser")]
        public async Task<Responses> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Responses.Success("User created successfully");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("updateuser/{id}")]
        public async Task<Responses> PostUser(int id, User user)
        {
            try
            {
                //Check if the the ids match
                if (id != user.Id)
                {
                    return Responses.Failure("User id does not match the User's Id");
                }
                //Checking if there are users in the database
                if (_context.Users == null)
                {
                    return Responses.Failure("There are no users in the database");
                }
                //Try to find the user
                var findUser = _context.Users.Where(p => p.Id == id).FirstOrDefault();
                #region
                //Same as above
                //foreach (var item in _context.Users)
                //{
                //    if (item.Id == id)
                //        findUser = item;
                //}
                #endregion
                //If user exists, Update the user
                if (findUser != null)
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return Responses.Success("User updated Successfully");
                }
                else
                {
                    return Responses.Failure($"User with Id {id} not found");
                }
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("deleteuser/{id}")]
        public async Task<Responses> DeleteUser(int id)
        {
            try
            {
                if (_context.Users == null)
                    return Responses.Failure("No User Found");
                var findUser = _context.Users.Where(p => p.Id == id).FirstOrDefault();
                if (findUser != null)
                {
                    _context.Users.Remove(findUser);
                    await _context.SaveChangesAsync();
                    return Responses.Success($"User with id{id} has been deleted");
                }
                else
                    return Responses.Failure($"User with Id{id} not found");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }
    }
}
