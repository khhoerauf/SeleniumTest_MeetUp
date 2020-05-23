using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest_MeetUp.PageObjectModel;
using Xunit;

namespace SeleniumTest_MeetUp
{
    public class TestSuit
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadMeetUpPage()
        {            
            using (IWebDriver driver = new ChromeDriver())
            {
                var home = new HomePage(driver);                     
                home.GoToHomePage();
            }        
        }

        [Fact]
        [Trait("Category", "Regression")]
        public void VerifyRegisterValidation()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var home = new HomePage(driver);
                home.GoToHomePage();
                var register = home.ClickOnJoinMeetUpButton();
                register.RegisterWithInvalidEmail();
            }
        }
    }
}
