using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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


    }


    public class AccountControllerRegister //nem találom a követelményeket
    {
        [Test,
           TestCase("Password", false),
            TestCase("ASAP", false),
            TestCase("password", false),
            TestCase("alma", false),
            TestCase("TokeleteSjelszO@1234_", true)


            ]
        public Match TestValidatePassword(string password)
        {

            Regex rgx = new Regex(@"^(.{8,}|[0-9] + [A-Z] + [a-z])$");
            return rgx.Match(password);


        }





        [Test,
            TestCase("irf@uni-corvinus.hu", "TokeleteSjelszO@1234_"), // miért nem kell ,hogy true vagy false?


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
            Assert.AreEqual(Guid.Empty, actualResult.ID);
        }




        [Test,
          TestCase("irf@uni-corvinus", "Abcd1234"),
            TestCase("irf.uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "abcd1234"),
            TestCase("irf@uni-corvinus.hu", "ABCD1234"),
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

                Assert.IsInstanceOf<ValidationException>(ex); //Ezt miért csináljuk?

            }
            // Assert
        }

    }
}
