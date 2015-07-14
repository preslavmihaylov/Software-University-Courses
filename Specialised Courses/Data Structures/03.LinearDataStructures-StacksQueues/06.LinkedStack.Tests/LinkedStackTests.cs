using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
public class LinkedStackTests
{
    private static LinkedStack<int> stack;

    [TestInitialize]
    public void TestInitialization()
    {
        stack = new LinkedStack<int>();
    }

    [TestMethod]
    public void TestPushingSeveralElements()
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);
        Assert.AreEqual(stack.Count, 7);
    }

    [TestMethod]
    public void TestPoppingSeveralElements()
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);

        Assert.AreEqual(stack.Pop(), 7);
        Assert.AreEqual(stack.Pop(), 6);
        Assert.AreEqual(stack.Pop(), 5);
        Assert.AreEqual(stack.Pop(), 4);

        Assert.AreEqual(stack.Count, 3);
    }

    [TestMethod]
    public void TestPushingManyElements()
    {
        for (int index = 0; index < 1000; index++)
        {
            stack.Push(index);
        }

        Assert.AreEqual(stack.Count, 1000);
    }

    [TestMethod]
    public void TestPoppingManyElements()
    {
        for (int index = 0; index < 1000; index++)
        {
            stack.Push(index);
        }

        for (int index = 999; index >= 0; index--)
        {
            Assert.AreEqual(stack.Pop(), index);
        }

        Assert.AreEqual(stack.Count, 0);
    }

    [TestMethod]
    public void TestLinkedStackToArray()
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);
        stack.Push(7);

        int[] stackArray = stack.ToArray();

        CollectionAssert.AreEqual(stackArray, new int[] { 7, 6, 5, 4, 3, 2, 1 });
    }

    [TestMethod]
    public void TestEmptyLinkedStackToArray()
    {
        int[] stackArray = stack.ToArray();

        CollectionAssert.AreEqual(stackArray, new int[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPoppingLinkedStackWithNoElements()
    {
        stack.Pop();
    }
}