using NUnit.Framework;

namespace draft.Test
{
    public class VaistineTest : BaseTest
    {  
        [Test]
        public static void TestMollersPrice()
        {
            _vaistineHomePage.NavigateToPage();
            _vaistineHomePage.CloseCookies();
            _vaistineHomePage.SearchByText("Moller");
            _vaistineSearchResultPage.OrderByHighestPrice();
            _vaistineSearchResultPage.VerifyPrice("20,04€");
        }

        [Test]
        public static void Test5MollersPrice()
        {
            _vaistineHomePage.NavigateToPage();
            _vaistineHomePage.CloseCookies();
            _vaistineHomePage.SearchByText("Moller");
            _vaistineSearchResultPage.OrderByHighestPrice();
            _vaistineSearchResultPage.AddToCart();
            _vaistineSearchResultPage.GoToCart();
            _cartPage.InsertQuantity(5);
            _cartPage.VerifyIfICanBuy(100);

        }
    }
}
