using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Page
{
    public class SearchResultsPage : BasePage
    {
        private const string highestPriceOptionText = "Kaina: nuo didžiausios iki mažiausios";

        private IReadOnlyCollection<IWebElement> resultList => Driver.FindElements(By.CssSelector(".item-box"));

        private SelectElement orderByDropdown => new SelectElement(Driver.FindElement(By.Id("products-orderby")));

        public SearchResultsPage(IWebDriver webdriver) : base(webdriver) { }

        public void OrderByHighestPrice()
        {
            orderByDropdown.SelectByText(highestPriceOptionText);
        }

        public void VerifyPrice(string price)
        {
            IWebElement firstItem = resultList.ElementAt(0);
            IWebElement oldPriceElemet = firstItem.FindElement(By.CssSelector(".price.old-price"));
            Assert.IsTrue(price.Equals(oldPriceElemet.Text), "Price is wrong");
        }
    }
}
