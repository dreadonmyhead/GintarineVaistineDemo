using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace draft.Page
{
    public class VaistineHomePage : BasePage
    {
        private const string PageAddress = "https://www.gintarine.lt/";
        private IWebElement searchField => Driver.FindElements(By.Id("small-searchterms")).ElementAt(1);
        public VaistineHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void CloseCookies()
        {
            Cookie cookie = new Cookie("CookieConsent",
                "{stamp:%27zHL4ElaTszQJp0PoqUYD8oWrhbzy0BsF3GeMApm27rrdTO5JTWsxTg==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cver:5%2Cutc:1667636298168%2Cregion:%27lt%27}",
                "www.gintarine.lt",
                "/",
                DateTime.Now.AddDays(5));
            Driver.Manage().Cookies.AddCookie(cookie);
            Driver.Navigate().Refresh();
        }

        public void SearchByText(string text)
        {
            searchField.Click();
            searchField.SendKeys(text);
            ClickOnSearchIcon();
        }

        public void ClickOnSearchIcon()
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Enter);
            action.KeyUp(Keys.Enter);
            action.Build().Perform();
        }
    }
}
