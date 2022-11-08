using draft.Drivers;
using draft.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace draft.Test
{
    public class BaseTest
    {
        private static IWebDriver driver;
        protected static VaistineSearchResultPage _vaistineSearchResultPage;
        protected static VaistineHomePage _vaistineHomePage;
        protected static CartPage _cartPage;


        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _vaistineSearchResultPage = new VaistineSearchResultPage(driver);
            _vaistineHomePage = new VaistineHomePage(driver);
            _cartPage = new CartPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}

