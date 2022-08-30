using API.Controllers;
using Domain.Entities;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UserManagement.Tests
{
    public class UsersControllerTests
    {
        public UsersControllerTests()
        {

        }
        [Fact]
        public void GetUsers()
        {
            //Arrange
            int count = 5;
            var fakeUsers = A.CollectionOfDummy<User>(count);
            var _context = A.Fake<AppDbContext>();
           // object value = A.CallTo(() => _context.Users.ToListAsync().Returns(Task.FromResult(fakeUsers));
            var controller = new UsersController(_context);
            
            //Act
            //Assert

        }
        public void GetUserTest()
        {

        }
        public void CreateUserTest()
        {

        }
        public void PostUserTest()
        {

        }
        public void DeleteUserTest()
        {

        }
    }
}