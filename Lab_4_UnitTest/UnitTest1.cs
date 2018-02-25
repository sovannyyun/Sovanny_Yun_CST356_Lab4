using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Repository;
using Sovanny_Yun_CST356_Lab3.Services;
using FakeItEasy;
using NUnit.Framework;

namespace Lab_4_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IUserRepository _userRepo;

        [SetUp]
        public void SetUp()
        {
            _userRepo = A.Fake<IUserRepository>();

        }



        [Test]
        public void CheckIfUserExists()
        {
            // Arrange
            A.CallTo(() => _userRepo.GetUser(A<int>.Ignored)).Returns(new User
            {
                Id = 0,
                DateOfBirth = new DateTime(2000, 12, 23),
                EmailAddress = "testc@gmail.com",
                FirstName = "Sovanny",
                LastName = "Yun",
                YearInSchoo = 20
            });

            // Act (SUT)
            var petService = new UserService(_userRepo);
            var petViewModel = petService.GetUser(0);

            // Assert
            NUnit.Framework.Assert.IsTrue(petViewModel.Id==1);
        }

    }
}
