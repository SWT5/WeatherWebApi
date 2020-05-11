using System;
using System.Collections.Generic;
using System.Text;
using Moq;
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
        }



        public List<user> RetrieveUser()
        {
            var UsersIn = new List<user>();
            UsersIn.Add(new user()
                {
                    UserId = "1337",
                    UserName = "KimJonUn",
                    PasswordHashed= "43243242"
                });

            return UsersIn;
        }


    }
}
