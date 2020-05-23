using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace SeleniumTest_MeetUp.PageObjectModel
{
    [Trait("Category", "Page")]
    public class RegisterPage
    {
        private readonly IWebDriver Driver;
        public RegisterPage(IWebDriver driver)
        {
            Driver = driver;
        }

        By registerWithEmail = By.Id("register-trigger--withEmail");
        By registerName = By.Id("register-field--name");
        By registerEmail = By.Id("register-field--email");
        By registerPassword = By.Id("register-field--password");
        By continueButton = By.XPath("//button[@type='submit");
        By securityCheckbox = By.XPath("//div[@class='recaptcha-checkbox-border']");

        protected string nameError => Driver.FindElement(By.Id("register-error--name")).Text;
        protected string emailError => Driver.FindElement(By.Id("register-error--email")).Text;
        protected string passwordError => Driver.FindElement(By.Id("Please enter a password.")).Text;
        protected bool RobotCheckbox => Driver.FindElements(By.XPath("//div[@id='rc-anchor-container']")).Any();

        public void RegisterWithInvalidEmail()
        {
            AccountParametersToRegisterWithEmail("test", "test", "test123");
            Assert.Equal("Doesn't look like an email address", emailError);
            ClickOnContinue();
            Assert.Equal("Doesn't look like an email address", emailError);
        }

        protected void AccountParametersToRegisterWithEmail(string name, string email, string password)
        {
            Driver.FindElement(registerWithEmail).Click();
            Driver.FindElement(registerName).SendKeys(name);
            Driver.FindElement(registerEmail).SendKeys(email);
            Driver.FindElement(registerPassword).SendKeys(password);
        }

        protected void ClickOnContinue()
        {
            if (RobotCheckbox)
            {
                Driver.FindElement(securityCheckbox).Click();
            }

            Driver.FindElement(continueButton).Click();
        }
    }
}
