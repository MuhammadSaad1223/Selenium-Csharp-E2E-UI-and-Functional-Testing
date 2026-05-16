using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography.X509Certificates;

namespace E2E_And_UI_POM.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver Driver;
        private WebDriverWait wait;

        public CheckoutPage(IWebDriver Driver)
        {
            this.Driver = Driver; 
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }
        public void CheckoutForminfo()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("first-name"))).SendKeys("Saad");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("last-name"))).SendKeys("Qureshi");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("postal-code"))).SendKeys("75100");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("continue"))).Click();
        }
            IWebElement PriceTotal => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-test=\"total-label\"]")));
            
            public Decimal GetTotalPrice()
            {
            string text = PriceTotal.Text.Replace("Total: $", "").Trim();

            if (decimal.TryParse(text, out decimal total))
                return total;

            return 0;
            }
        }
    }
