using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace draft.Page
{
    public class VaistineHomePage : BasePage
    {
        private const string PageAddress = "https://www.gintarine.lt/";
        private IWebElement cookieButton => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement searchField => Driver.FindElement(By.Id("small-searchterms"));
        private IWebElement searchIcon => Driver.FindElement(By.CssSelector(".button-1.search-box-button"));
        public VaistineHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void CloseCookies()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")));
            cookieButton.Click();
        }

        public void SearchByText(string text)
        {
            searchField.Clear();
            searchField.SendKeys(text);
            searchIcon.Click();
        }

        public void ClickOnSearchIcon()
        {
            searchIcon.Click();
        }

    }
}
