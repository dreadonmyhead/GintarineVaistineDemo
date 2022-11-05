using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace draft.Page
{
    public class CartPage : BasePage
    {
        private IWebElement totalPriceElement => Driver.FindElement(By.CssSelector(".cart__summary-total > .cart__summary-price"));
        public CartPage(IWebDriver webdriver) : base(webdriver) { }

        public void InsertQuantity(int quantity)
        {
            IWebElement quantityField = Driver.FindElement(By.Name("addtocart_32657.EnteredQuantity"));
            Actions action = new Actions(Driver);
            action.DoubleClick(quantityField);
            action.Build().Perform();
            quantityField.SendKeys(quantity.ToString());
            action.KeyDown(Keys.Enter);
            action.KeyUp(Keys.Enter);
            action.Build().Perform();
        }

        public void VerifyIfICanBuy(int moneyToSpent)
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".notification notification--success")));
            double totalPrice = double.Parse(totalPriceElement.Text.Replace("€", ""));
            Assert.IsTrue(moneyToSpent > totalPrice, $"Cannot by 5 mollers with 100€, total price is {totalPrice}");
        }
    }
}
