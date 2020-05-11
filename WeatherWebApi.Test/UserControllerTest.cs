using System;
using System.Collections.Generic;
using System.Text;
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
            var mockS = new Mock<IuserCrud>();
            mockS.Setup(mockS => mockS.Get())
                .Returns(RetrieveUser());

            //Create the controller in use 
            var controller = new userController(mockS.Object);

            var retrieved = controller.Get("KimJongUn");


            Assert.Collection(retrieved.ToString(), item => Assert.Contains("KimJongUn", ));


            //Assert.Equal("KimJongUn", retrieved.ToString());


            //Assert.Collection(retrieved, item => Assert.Contains("KimJongUn", item.));

            //assert that we did get the right user
            //Assert.Collection(retrieved.ToString(), i => Assert.Contains("1337",));
            //Assert.Contains("KimJongUn", retrieved.ToString());

            //Assert.All(retrieved, i => Assert.Contains("1337",));

        }



        private List<user> RetrieveUser()
        {
            var UsersIn = new List<user>();
            UsersIn.Add(new user()
                {
                    UserId = "1337",
                    UserName = "KimJongUn",
                    PasswordHashed= "43243242"
                });
            return UsersIn;
        }
    }
}
