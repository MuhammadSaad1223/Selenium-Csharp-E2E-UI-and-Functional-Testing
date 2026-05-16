using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace E2E_And_UI_POM.Pages
{
    public class Cartpage
    {
        private readonly IWebDriver Driver;
        private WebDriverWait wait;

        public Cartpage(IWebDriver driver)
        {
            this.Driver = driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }
        #region Locators:
        IWebElement GoToCart => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-test=\"shopping-cart-link\"]")));
        IWebElement Checkout => wait.Until(ExpectedConditions.ElementExists(By.Id("checkout")));
        IWebElement CartBadge => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-test=\"shopping-cart-link\"]")));
        IWebElement VerifyBikeLightExist => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'Sauce Labs Bike Light']")));

        #endregion.


        #region Methods:
        public void GoToCart_()
        {
            GoToCart.Click();
        }
        public void Checkout_()
        {
            Checkout.Click();
        }
        public int GetCartBadgeCount()
        {
            var text = CartBadge.Text;

            if (int.TryParse(text, out int count))
                return count;

            return 0;
        }
        public bool VerifyBikeLightIsPresentInCart()
        {
            return VerifyBikeLightExist.Displayed;
        }

        #endregion.
    }
}
      