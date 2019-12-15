using AutoT.Interfaces;
using AutoT.Models;
using AutoT.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void AutoUnitTest()
        {
            var fakeRepository = Mock.Of<IUser>();
            var userService = new UserService(fakeRepository);

            List<User> users = new List<User>
            {
                  new User() { UserName = "Salam aleikum" },
                new User() { UserName = "Aleikum salam"},
            };
        }

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IUser>();
            var userService = new UserService(fakeRepository);

            var user = new User() { UserName = "Salam Aleikum"};
            await userService.AddAndSave(user);
        }

        [Fact]
        public async Task GetUsersTest()
        {
            var users = new List<User>
            {
                  new User() { UserName = "Salam aleikum" },
                new User() { UserName = "Aleikum salam"},
            };

            var fakeRepositoryMock = new Mock<IUser>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);

            var userService = new UserService(fakeRepositoryMock.Object);

            var resultUsers = await userService.GetUsers();

            Assert.Collection(resultUsers, movie =>
            {
                Assert.Equal("Salam aleikum", movie.UserName);
            },
            movie =>
            {
                Assert.Equal("Aleikum salam", movie.UserName);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IUser>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(user);

            var userService = new UserService(fakeRepositoryMock.Object);

            await userService.DeleteUser(2);
        }

        private List<User> user()
        {
            throw new NotImplementedException();
        }




    }
}
