using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Common;
using Domain.ViewModels;
using Domain.DTOs;
using Domain.Enums;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet("getemployees")]
        public async Task<Responses> GetEmployees()
        {
            try
            {
                if (_context.Employees == null)
                {
                    return Responses.Failure("No Employee Found");
                }
                var employees = await _context.Employees.ToListAsync();
                return Responses.Success("Employees found", employees);
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // GET: api/Employees/5
        [HttpGet("geteemployee/{id}")]
        public async Task<Responses> GetEmployee(int id)
        {
            try
            {
                if (_context.Employees == null)
                {
                    return Responses.Failure("No Employee Found");
                }
                var employee = await _context.Employees.Where(a => a.Id == id).FirstOrDefaultAsync();
                
                if (employee == null)
                {
                    return Responses.Failure($"Employee with id {id} not Found");
                }
                return Responses.Success("Employee found", employee);
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        [HttpPut("updateemployee/{id}")]
        public async Task<Responses> UpdateEmployee(int id, UpdateEmployeeDTO request)
        {
            try
            {
                //Check if employee exists
                var employeeExists = await _context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();

                if (employeeExists != null)
                {
                    employeeExists.Organization = request.Organization;
                    employeeExists.Status = request.Status;
                    employeeExists.DateModified = DateTime.Now;

                    _context.Employees.Update(employeeExists);
                    await _context.SaveChangesAsync();
                    return Responses.Success("Employee updated successfully");
                }
                else
                {
                    return Responses.Failure($"Employee with id {id} not found");
                }
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        [HttpPost("createemployee")]
        public async Task<Responses> CreateEmployee(CreateEmployeeDTO request)
        {
            try
            {
                //Check if user exists
                var userExists = _context.Users.Any(e => e.Id == request.UserId);
                if (userExists)
                {
                    var employee = new Employee
                    {
                        Organization = request.Organization,
                        UserId = request.UserId,
                        DateCreated = DateTime.Now,
                        Status = Status.Active
                    };
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return Responses.Success("employee created Successfully", employee);
                }
                else
                    return Responses.Failure($"User with id {request.UserId} not found");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<Responses> DeleteEmployee(int id)
        {
            try
            {
                if (_context.Employees == null)
                {
                    return Responses.Failure("No Employee Found");
                }
                var todelete = await _context.Employees.Where(a => a.Id == id).FirstOrDefaultAsync();
                if (todelete != null)
                {
                    _context.Employees.Remove(todelete);
                    await _context.SaveChangesAsync();
                    return Responses.Success("Employee deleted Successfully");
                }
                else
                    return Responses.Failure($"Employee with id {id} not found");
            }
            catch (Exception ex)
            {
                return Responses.Failure(ex.Message);
            }
            var employee = await _context.Employees.FindAsync(id);
        }
    }
}
