using System.Collections.Generic;
using Moq;
using WeatherWebApi.Controllers;
using WeatherWebApi.Models;
using WeatherWebApi.Services;
using Xunit;

namespace WeatherWebApi.Test
{
    public class UserControllerTest
    {
        [Fact]
        public void Test_Does_User_Exist()
        {
            var mo = new Mock<IUserCrud>();
            mo.Setup(mo => mo.Get())
                .Returns(RetrieveUser());

            //Create the controller in use 
            var controller = new userController(mo.Object);

            var retrieved = controller.Get("KimJongUn");

            Assert.Collection(retrieved, item => Assert.Contains("KimJongUn", item.UserName)); 

        }



        private List<user> RetrieveUser()
        {
            var UsersIn = new List<user>();
            UsersIn.Add(new user()
                {
                    UserName = "KimJongUn",
                    PasswordHashed= "43243242"
                });
            return UsersIn;
        }
    }
}
