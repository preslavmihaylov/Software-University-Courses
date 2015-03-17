using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedListUnitTests
{
    using System;
    using CustomLinkedList;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestCountAtNoElements()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();
            Assert.AreEqual(0, dynamicList.Count);
        }

        [TestMethod]
        public void TestAddingElements()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();
            dynamicList.Add("Gosho");
            Assert.AreEqual("Gosho", dynamicList[0]);

            dynamicList.Add("Pesho");
            dynamicList.Add("Nasko");
            dynamicList.Add("Toshko");
            dynamicList.Add("Karlo");

            Assert.AreEqual("Pesho", dynamicList[1]);
            Assert.AreEqual("Nasko", dynamicList[2]);
            Assert.AreEqual("Toshko", dynamicList[3]);
            Assert.AreEqual("Karlo", dynamicList[4]);
        }

        [TestMethod]
        public void TestRemovingElements()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();
            dynamicList.Add("Gosho");

            dynamicList.Add("Pesho");
            dynamicList.Add("Nasko");

            dynamicList.Remove("Pesho");
            Assert.AreEqual("Nasko", dynamicList[1]);
            Assert.AreEqual(-1, dynamicList.Remove("Pesho"));
        }

        [TestMethod]
        public void TestRemovingElementAtIndex()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();
            dynamicList.Add("Gosho");

            dynamicList.Add("Pesho");
            dynamicList.Add("Nasko");

            dynamicList.RemoveAt(1);
            Assert.AreEqual("Nasko", dynamicList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAccessingInvalidIndex()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();
            dynamicList.Add("Gosho");
            dynamicList.Add("Pesho");
            dynamicList.Add("Nasko");

            Console.WriteLine(dynamicList[5]);
        }

        [TestMethod]
        public void TestSettingItemByIndex()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();
            dynamicList.Add("Gosho");
            dynamicList.Add("Tosho");
            dynamicList[1] = "Pesho";
            Assert.AreEqual("Pesho", dynamicList[1]);
        }

        [TestMethod]
        public void TestSearchingForElement()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(5);
            dynamicList.Add(10);
            dynamicList.Add(15);

            Assert.AreEqual(1, dynamicList.IndexOf(10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingElementAtInvalidIndex()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();
            dynamicList[0] = 10;
        }

        [TestMethod]
        public void TestContainsMethod()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(5);

            Assert.AreEqual(false, dynamicList.Contains(10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemovingElementAtInvalidIndex()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();
            dynamicList.Add(6);
            dynamicList.RemoveAt(1);
        }

        [TestMethod]
        public void TestRemovingMultipleElements()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();
            dynamicList.Add(10);
            dynamicList.Add(15);
            dynamicList.Add(20);
            dynamicList.Add(5);

            dynamicList.Remove(10);
            dynamicList.Remove(15);
            dynamicList.Remove(20);

            Assert.AreEqual(5, dynamicList[0]);

            dynamicList.Remove(5);
            Assert.AreEqual(0, dynamicList.Count);
        }
    }
}
