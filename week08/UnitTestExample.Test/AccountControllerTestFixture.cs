using NUnit.Framework;
using System;
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
            var accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);

        }


    }


    public class AccAccountControllerRegister //nem találom a követelményeket
    {
        [Test,
           TestCase("Password", false),
            TestCase("ASAP", false),
            TestCase("password", false),
            TestCase("alma", false),
            TestCase("TokeleteSjelszO@1234_", true)


            ]
        public Match TestValidatePassword(string password, bool expextedResult)
        {

            Regex rgx = new Regex(@"^(.{8}|[0-9] + [A-Z] + [a-z])$");
            return rgx.Match(password);

        }

        [Test,
            TestCase("irf@uni-corvinus.hu", "TokeleteSjelszO@1234_"), // miért nem kell ,hogy true vagy false?


            ]
        public void TestRegisterHappyPath(string email, string password)
        {
            var ac = new AccountController();
            var actualResult = ac.Register(email, password);
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);

            Assert.AreEqual(Guid.Empty, actualResult.ID);

        
        
        
        }
    }
}
