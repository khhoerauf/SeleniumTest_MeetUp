using OpenQA.Selenium;
using SeleniumTest_MeetUp.PageObjectModel;
using Xunit;

namespace SeleniumTest_MeetUp
{
    [Trait("Category","Page")]
    public class HomePage
    {
        private readonly IWebDriver Driver;
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }
        
        public void GoToHomePage()
        {
            Driver.Navigate().GoToUrl("https://www.meetup.com/");
            string pageTitle = Driver.Title;
            Assert.Contains("Meetup", pageTitle);
        }

        public RegisterPage ClickOnJoinMeetUpButton()
        {
            Driver.FindElement(By.Id("joinMeetupButton")).Click();
            return new RegisterPage(Driver);
        }
    }
}
