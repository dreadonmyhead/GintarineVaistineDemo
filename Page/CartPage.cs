using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace draft.Page
{
    public class CartPage : BasePage
    {
        private IWebElement totalPriceElement => Driver.FindElement(By.CssSelector(".product-subtotal"));
        private IWebElement increaseQuantity => Driver.FindElement(By.CssSelector(".increase"));
        public CartPage(IWebDriver webdriver) : base(webdriver) { }

        public void InsertQuantity()
        {
            for (int i = 1; i < 5; i++)
            {
                increaseQuantity.Click();
                Thread.Sleep(4000); //TODO
            }
        }

        public void VerifyIfICanBuy(int moneyToSpent)
        {
            double totalPrice = double.Parse(totalPriceElement.Text.Replace("€", ""));
            Assert.IsTrue(moneyToSpent > totalPrice, $"Cannot by 5 mollers with 100€, total price is {totalPrice}");
        }
    }
}
