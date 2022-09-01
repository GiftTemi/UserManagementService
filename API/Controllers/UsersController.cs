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
        [HttpGet]
        public async Task<Responses> GetUsers()
        {
            try
            {
                var findUsers = await _context.Users.ToListAsync();
                if (findUsers == null)
                {
                    return Responses.Failure("Users Not found");
                }
                return Responses.Success("Suceeded", findUsers);
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<Responses> GetUser(int id)
        {
            try
            {
                var findUser = await _context.Users.Where(q => q.Id == id).FirstOrDefaultAsync();
                if (findUser == null)
                    return Responses.Failure($"User with Id {id} not found");
                else
                    return Responses.Success("suceeded", findUser);
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Responses> UpdateUser(int id, User user)
        {
            try
            {
                var findUser = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (findUser == null)
                    return Responses.Failure("User not found");
                else
                {
                    findUser.DOB = user.DOB;
                    findUser.Status = user.Status;
                    findUser.DateModified = user.DateModified;
                    findUser.FirstName = user.FirstName;
                    findUser.lastName = user.lastName;

                    _context.Update(findUser);
                    await _context.SaveChangesAsync();
                    return Responses.Success("User updated successfully", findUser);
                }

            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        [HttpPost]
        public async Task<Responses> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Responses.Success("User Created Successfully");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<Responses> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return Responses.Failure("User not found");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Responses.Success("User deleted Successfully");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

    }
}
