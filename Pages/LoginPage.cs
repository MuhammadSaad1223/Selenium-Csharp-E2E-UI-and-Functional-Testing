using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

namespace E2E_And_UI_POM.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver Driver;
        private WebDriverWait wait;    //Explicit waits

        public LoginPage(IWebDriver Driver)
        {
            this.Driver = Driver;
          wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); 
        }

        #region locators:
        public void login(string username, string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name"))).SendKeys(username);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password"))).SendKeys(password);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button"))).Click();
        }

        IWebElement Errormsg => Driver.FindElement(By.XPath("//h3[@data-test='error']"));
        #endregion locators.

        public bool IsLoginSuccessful()
        {
            return Driver.Url.Contains("/inventory.html");
        }

        public string GetErrorMessage()
        {
            return Errormsg.Text;
        }
    }
}