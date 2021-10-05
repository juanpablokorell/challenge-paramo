using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Core.Builder;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enumerator;
using Sat.Recruitment.Core.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.UserCreatedTest
{
    public class UserCreatedTest
    {
        private Mock<IUserBuilder> _userBuilder;
        private Mock<IUserServicies> _userServicies;

        private Mock<IUserFileRepository> _MockRepository = new Mock<IUserFileRepository>();


        public UserCreatedTest()
        {
            _userBuilder = new Mock<IUserBuilder>();
            _userServicies = new Mock<IUserServicies>();

        }


        [Fact]
        public async Task Created_User_Not_Existent()
        {
            //Arrange
            var userController = new UsersController(_userBuilder.Object, _userServicies.Object);

            var EntityModel = Mock.Of<User>(u => u.Name == "Mike" &&
                                            u.Email == "mike@gmail.com" &&
                                            u.Address == "Av. Juan G" &&
                                            u.Phone == "+349 1122354215" &&
                                            u.UserType == UserTypes.Normal.ToString() &&
                                            u.Money == 124);
            _userServicies
                .Setup(u => u.ExistUser(EntityModel))
                .ReturnsAsync(false);

            _userServicies
                .Setup(u => u.AddUser(EntityModel));

            var model = Mock.Of<UserDTO>(u => u.Name == "Mike" &&
                                           u.Email == "mike@gmail.com" &&
                                           u.Address == "Av. Juan G" &&
                                           u.Phone == "+349 1122354215" &&
                                           u.UserType == UserTypes.Normal.ToString() &&
                                           u.Money == 124);

            _userBuilder
                .Setup(u => u.Build(model))
                .Returns(EntityModel);

            //Fact
            var result = await userController.Post(model);

            //Asert
            Assert.True(result is CreatedAtActionResult);
            Assert.Equal(Microsoft.AspNetCore.Http.StatusCodes.Status201Created, ((CreatedAtActionResult)result).StatusCode);
        }

        [Fact]
        public async Task Created_User_Existent_Error()
        {
            //Arrange
            var userController = new UsersController(_userBuilder.Object, _userServicies.Object);

            var EntityModel = Mock.Of<User>(u => u.Name == "Agustina" &&
                                            u.Email == "Agustina@gmail.com" &&
                                            u.Address == "Av. Juan G" &&
                                            u.Phone == "+349 1122354215" &&
                                            u.UserType == UserTypes.Normal.ToString() &&
                                            u.Money == 124);
            _userServicies
                .Setup(u => u.ExistUser(EntityModel))
                .ReturnsAsync(true);

            _userServicies
                .Setup(u => u.AddUser(EntityModel));

            var model = Mock.Of<UserDTO>(u => u.Name == "Agustina" &&
                                           u.Email == "Agustina@gmail.com" &&
                                           u.Address == "Av. Juan G" &&
                                           u.Phone == "+349 1122354215" &&
                                           u.UserType == UserTypes.Normal.ToString() &&
                                           u.Money == 124);

            _userBuilder
                .Setup(u => u.Build(model))
                .Returns(EntityModel);

            //Fact
            var result = await userController.Post(model);

            //Asert
            Assert.True(result is ConflictObjectResult);
            Assert.Equal(Microsoft.AspNetCore.Http.StatusCodes.Status409Conflict, ((ConflictObjectResult)result).StatusCode);
        }

    }
}
