using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Page
{
    public class GintarineHomePage : BasePage
    {
        private IWebElement allowAllCookiesButton => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement searchInput => Driver.FindElement(By.Id("small-searchterms"));
        private IWebElement searchIcon => Driver.FindElement(By.CssSelector(".button-1.search-box-button"));
        public GintarineHomePage(IWebDriver webdriver) : base (webdriver) { }

        public void SearchByText(string searchText)
        {
            searchInput.Clear();
            searchInput.SendKeys(searchText);
            searchIcon.Click();
        }

        public void CloseCookie()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Displayed);
            allowAllCookiesButton.Click();
        }

        public void PressOnSearchIcon()
        {
            searchIcon.Click();
        }


    }
}
