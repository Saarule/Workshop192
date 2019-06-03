using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;
using Workshop192.UserManagment;

namespace DomainLayerUnitTests.MarketManagment
{
    [TestFixture]
    class CartTests
    {
        private Cart cart;
        private Product p1;

        [SetUp]
        public void SetUp()
        {
            Store store = new Store("newStore");
            p1 = new Product(1, "air", "element", 5);
            store.AddProducts(p1, 4);
            cart = new Cart(store);
        }
    }
}
