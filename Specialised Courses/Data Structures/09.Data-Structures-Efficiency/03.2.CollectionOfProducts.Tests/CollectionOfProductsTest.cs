namespace _03._2.CollectionOfProducts.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _03.CollectionOfProducts;

    [TestClass]
    public class CollectionOfProductsTest
    {
        private ICollectionOfProducts products;

        [TestInitialize]
        public void TestInitialize()
        {
            //this.products = new ProductCollectionSlow();
            this.products = new CollectionOfProducts();
        }

        private void AddProducts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.products.Add(
                    new Product()
                    {
                        Id = i,
                        Title = "product" + i,
                        Price = i % 100,
                        Supplier = "supplier" + (i % 100)
                    });
            }
        }

        [TestMethod]
        [Timeout(250)]
        public void TestPerformance_AddProduct()
        {
            // Act
            AddProducts(5000);
            Assert.AreEqual(5000, this.products.Count);
        }

        [TestMethod]
        // [Timeout(200)]
        public void TestPerformance_FindProduct()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 5000; i++)
            {
                var existingProduct = this.products.Find(i);
                Assert.IsNotNull(existingProduct);

                var nonExistingProduct = this.products.Find(5050);
                Assert.IsNull(nonExistingProduct);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformance_FindProductsByTitleAndPrice()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.Find("product0", 0).ToList();
                Assert.AreEqual(1, existingProducts.Count);

                var notExistingProducts =
                    this.products.Find("product0", 90).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(450)]
        public void TestPerformance_FindProductsByPriceRange()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 2000; i++)
            {
                var existingProducts =
                    this.products.Find(51, 55).ToList();
                Assert.AreEqual(250, existingProducts.Count);

                var notExistingProducts =
                    this.products.Find(110, 150).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformance_FindProductsByTitleAndPriceRange()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.Find("product1", 0, 20).ToList();
                Assert.AreEqual(1, existingProducts.Count);

                var notExistingProducts =
                    this.products.Find("product1", 10, 20).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformance_FindProductsByTitle()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.Find("product1").ToList();
                Assert.AreEqual(1, existingProducts.Count);

                var notExistingProducts =
                    this.products.Find("non-existing product").ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformance_FindProductsBySupplierAndPrice()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.FindBySupplier("supplier1", 1).ToList();
                Assert.AreEqual(50, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindBySupplier("supplier1", 50).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(250)]
        public void TestPerformance_FindProductsBySupplierAndPriceRange()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 2000; i++)
            {
                var existingProducts =
                    this.products.FindBySupplier("supplier1", 0, 20).ToList();
                Assert.AreEqual(50, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindBySupplier("supplier1", 50, 60).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformance_RemoveProductById()
        {
            // Arrange
            AddProducts(5000);

            // Act
            for (int i = 0; i < 5000; i++)
            {
                bool hasRemovedExistingProduct =
                    this.products.Remove(i);
                Assert.IsTrue(hasRemovedExistingProduct);

                bool hasRemovedNonExistingProduct =
                    this.products.Remove(5050);

                Assert.IsFalse(hasRemovedNonExistingProduct);
            }
        }
    }
}
