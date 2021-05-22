using System;
using FinalProject.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProject.Test
{
    public class GintarineTest
    {
        private static GintarineHomePage _homePage;
        private static SearchResultsPage _searchPage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://www.gintarine.lt/";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _homePage = new GintarineHomePage(_driver);
            _searchPage = new SearchResultsPage(_driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            _homePage.CloseBrowser();
        }

        [Test]
        public static void TestMostExcepsiveMollers()
        {
            _homePage.CloseCookie();
            _homePage.SearchByText("Moller");
            _searchPage.OrderByHighestPrice();
            _searchPage.VerifyPrice("18,51€");
        }

    }
}
