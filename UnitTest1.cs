using E2E_And_UI_POM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using POMPractice.Pages;

namespace POMPractice
{
    [TestFixture]
    public class Tests
    {
        IWebDriver Driver;

        // Runs before every test
        [SetUp]
        public void Setup()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        // Reusable login method
        // This method uses LoginPage class to perform login
        // It keeps test methods clean and avoids duplicate code
        public void TestLogin(string username, string password)
        {
            LoginPage loginPage = new LoginPage(Driver);

            // Perform login steps (enter username, password, click login)
            loginPage.login(username, password); 
        }

        /*
         This test runs multiple times with different users using TestCase
         Each TestCase provides a different username/password combination
         This is called Data-Driven Testing
        */
        [Test]
        [TestCase("standard_user", "secret_sauce")]  // valid login
        [TestCase("problem_user", "wrongpass")]      // invalid login
        public void LoginTest(string username, string password)
        {
            //Page Object for login page
            LoginPage loginPage = new LoginPage(Driver);
            
            // Reuse login method
            TestLogin(username, password);

            //Real Testing Assertions for valid and invalid user in a single method using conditional statement:
            if (username == "standard_user" && password == "secret_sauce")
            {
                Assert.That(loginPage.IsLoginSuccessful(), Is.True, "Should redirect to homepage on login");
            }
            else { 
               
                Assert.That(loginPage.GetErrorMessage(),Does.Contain("Epic sadface: Username and password do not match any user in this service"));
            }
        }

        [Test]
        public void Shopping()
        {
            // Page objects:
            HomePage homePage = new HomePage(Driver);
            Cartpage cartpage = new Cartpage(Driver);
            CheckoutPage Checkout1 = new CheckoutPage(Driver);

            // Login with valid user
            TestLogin("standard_user", "secret_sauce");

            // Perform actions on Home Page
            homePage.AddBackpackToCart();
            homePage.AddBikeLightToCart();
            homePage.RemoveBackpack_();

            Assert.That(cartpage.GetCartBadgeCount(), Is.EqualTo(1), "There is Only one item in Cart");

            /// Goes To Cart and Checks weather the product is there or not? If yes proceeds to checkout\\\\
            cartpage.GoToCart_();
            Assert.That(cartpage.VerifyBikeLightIsPresentInCart(), Is.True, "Bike light product exist in cart");

            //Performs actions on cartpage
            cartpage.Checkout_();

            ////Fills Info on YourInformation form\\\\\\
            Checkout1.CheckoutForminfo();

            ///Converts String into Decimal number and check the value is greater or less\\\
            Assert.That(Checkout1.GetTotalPrice(), Is.Not.GreaterThan(11));
            //Assert.That(PriceTotal.Displayed, Is.True);
            homePage.ClickFinish();
        }

        // Runs after every test
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}