using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace draft.Page
{
    public class VaistineSearchResultPage : BasePage
    {
        private const string orderByHighestPriceText = "Kaina: nuo didžiausios iki mažiausios";
        private IWebElement addToCardButton => Driver.FindElement(By.CssSelector(".button-1.productAddedToCartWindowCheckout"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".item-box"));
        private SelectElement orderByDropdown => new SelectElement(Driver.FindElement(By.Id("products-orderby")));

        public VaistineSearchResultPage(IWebDriver webdriver) : base(webdriver) { }
        public void OrderByHighestPrice()
        {
            GetWait().Until(driver => driver.FindElement(By.CssSelector(".page-title-holder > h1")).Displayed);
            orderByDropdown.SelectByText(orderByHighestPriceText);
        }

        public void VerifyPrice(string price)
        {
            IWebElement firstResultElement = results.ElementAt(0);
            string firstResultElementPrice = firstResultElement.FindElement(By.CssSelector(".price.actual-price")).Text;
            Assert.AreEqual(price, firstResultElementPrice, "Price is wrong");
        }

        public void AddToCard()
        {
            IWebElement firstResultElement = results.ElementAt(0);
            Actions action = new Actions(Driver);
            IWebElement imageElement = firstResultElement.FindElement(By.CssSelector(".picture-img"));
            action.MoveToElement(imageElement);
            action.Build().Perform();
            firstResultElement.FindElement(By.CssSelector(".button-2.product-box-add-to-cart-button.nopAjaxCartProductListAddToCartButton")).Click();
            addToCardButton.Click();
        }
    }
}
