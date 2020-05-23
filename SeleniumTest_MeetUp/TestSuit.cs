using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void VerifyRegisterWithInvalidEmial()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var home = new HomePage(driver);
                home.GoToHomePage();
                var register = home.ClickOnJoinMeetUpButton();
                register.RegisterWithInvalidEmail();
            }
        }

        [Fact]
        [Trait("Category", "Regression")]
        public void VerifyRegisterWithEmptyName()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var home = new HomePage(driver);
                home.GoToHomePage();
                var register = home.ClickOnJoinMeetUpButton();
                register.RegisterWithEmptyName();
            }
        }

        [Fact]
        [Trait("Category", "Regression")]
        public void VerifyRegisterWithInvalidPassword()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var home = new HomePage(driver);
                home.GoToHomePage();
                var register = home.ClickOnJoinMeetUpButton();
                register.RegisterWithInvalidPassword();
            }
        }
    }
}
