using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace draft.Page
{
    public class VaistineSearchResultPage : BasePage
    {
        private const string orderByHighestPriceText = "Aukščiausia kaina viršuje";
        private IWebElement goToCartLink => Driver.FindElement(By.LinkText("prekių krepšelį"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".category-products__cards"));
        private SelectElement orderByDropdown => new SelectElement(Driver.FindElement(By.Id("categoryProductsSorter")));

        public VaistineSearchResultPage(IWebDriver webdriver) : base(webdriver) { }
        public void OrderByHighestPrice()
        {
            GetWait().Until(driver => driver.FindElement(By.CssSelector("div.category-products__description > h1")).Displayed);
            orderByDropdown.SelectByText(orderByHighestPriceText);
        }

        public void VerifyPrice(string price)
        {
            IWebElement firstResultElement = results.ElementAt(0);
            string firstResultElementPrice = firstResultElement.FindElement(By.CssSelector(".product__price--regular")).Text;
            Assert.AreEqual(price, firstResultElementPrice, "Price is wrong");
        }

        public void AddToCart()
        {
            IWebElement firstResultElement = results.ElementAt(0);
            Actions action = new Actions(Driver);
            IWebElement imageElement = firstResultElement.FindElement(By.CssSelector(".picture-img"));
            action.MoveToElement(imageElement);
            action.Build().Perform();
            firstResultElement.FindElement(By.CssSelector(".btn.btn__primary.add-to-cart")).Click();
        }

        public void GoToCart()
        {
            GetWait().Until(driver => driver.FindElement(By.CssSelector(".notification__content")).Displayed);
            goToCartLink.Click();
        }
    }
}
