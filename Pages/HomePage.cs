using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace POMPractice.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }
       
        #region Locators:
        IWebElement Backpack => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'Sauce Labs Backpack']")));
        IWebElement Addtocart => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("add-to-cart")));
        IWebElement BackToProducts => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("back-to-products")));
        IWebElement BikeLight => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'Sauce Labs Bike Light']")));
        IWebElement RemoveBackpack => wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"remove-sauce-labs-backpack\"]")));
        IWebElement Finish => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("finish")));
        IWebElement BackToProductsPage => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("back-to-products")));
        #endregion:


        #region Methods:
        public void AddBackpackToCart()          //// Adding products to cart and than removing one item \\\\\\
                                                 //// Comes In Functional, E2E mainly and Ui testing. \\\\\\
        {
           Backpack.Click();
           Addtocart.Click();
           BackToProducts.Click();
        }

        public  void AddBikeLightToCart()
        {
            BikeLight.Click();
            Addtocart.Click();
            BackToProducts.Click();
        }

        public void RemoveBackpack_()
        {
            RemoveBackpack.Click();
        }
        
       
        public void ClickFinish()
        {
            Finish.Click();
            BackToProductsPage.Click();
        }
        #endregion
    }
}