
using Exo.WebApi.Controllers;
using Exo.WebApi.Interface;
using Exo.WebApi.Models;
using Exo.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExo.Controller
{
    public class LoginControllerTest
    {
        [Fact]
        public void LoginController_Return_Invalid_User()
        {
            //arrange
            var fakeRepository = new Mock<IUserRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((User)null);

            LoginViewModel LoginData = new LoginViewModel();

            LoginData.Email = "email@gmail.com";
            LoginData.Senha = "123";

            var controller = new LoginController(fakeRepository.Object);

            // act
            var result = controller.Login(LoginData);

            //assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
        [Fact]
        public void LoginController_Return_Token()
        {
            User userReturn = new User();
            userReturn.Email = "email@gmail.com";
            userReturn.Senha = "123";
            userReturn.Tipo= "1";

            var fakeRepository = new Mock<IUserRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(userReturn);

            string issuerValidation = "Exo.WebAPi";

            LoginViewModel LoginData = new LoginViewModel();
            LoginData.Email = "batata";
            LoginData.Senha = "1234";

            var controller = new LoginController(fakeRepository.Object);
            
            OkObjectResult result = (OkObjectResult)controller.Login(LoginData);

            string token = result.Value.ToString().Split("")[3];

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJet = jwtHandler.ReadToken(token);

            Assert.Equal(issuerValidation, tokenJet.Issuer);

        }
    }
}
