using NUnit.Framework;
using System;
using System.Activities;
using System.Text.RegularExpressions;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test,
            TestCase("password1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)

            ]

        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }




        [Test,
           TestCase("Password", false), //nincs szam
            TestCase("ASAP", false), //nincs kisbetű 
            TestCase("password", false), //nincs nagybetű
            TestCase("psw", false), //túl rövid
            TestCase("Password12345", true)


            ]

        public void TestValidatePassword(string password, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidatePassword(password);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);


        }

     



        [Test,
            TestCase("irf@uni-corvinus.hu", "TokeleteSjelszO1234"), 


            ]
        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var ac = new AccountController();

            // Act
            var actualResult = ac.Register(email, password);

            // Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }




        [
          Test,
          TestCase("irf@uni-corvinus", "Abcd1234"),
          TestCase("irf.uni-corvinus.hu", "Abcd1234"),
          TestCase("irf@uni-corvinus.hu", "abcd1234"),
          TestCase("irf@uni-corvinus.hu", "ABCD1234"),
          TestCase("irf@uni-corvinus.hu", "abcdABCD"),
          TestCase("irf@uni-corvinus.hu", "Ab1234"),
      ]
        public void TestRegisterValidateException(string email, string password)
        {
            // Arrange
            var ac = new AccountController();
            try
            {
                // Act
                var actualResult = ac.Register(email, password);
                Assert.Fail();

            }
            catch (Exception ex)
            {
                
                Assert.IsInstanceOf<ValidationException>(ex); 

            }
            // Assert
        }

    }
}
