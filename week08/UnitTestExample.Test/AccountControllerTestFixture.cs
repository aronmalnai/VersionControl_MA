using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            TestCase("ASAP",false),
            TestCase("password",false ),
            TestCase("alma", false),
            TestCase("TokeleteSjelszO@1234_",true)

            
            ]
        public void TestValidatePassword(string password, bool expextedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidatePassword(password);
            Assert.AreEqual(expextedResult, actualResult);
            




        }
    
    
    }
}
