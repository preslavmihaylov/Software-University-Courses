using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class LinkedQueueTests
{
    [TestMethod]
    public void Enqueue_EmptyQueue_ShouldAddElement()
    {
        // Arrange
        var queue = new LinkedQueue<int>();

        // Act
        queue.Enqueue(5);

        // Assert
        Assert.AreEqual(1, queue.Count);
    }

    [TestMethod]
    public void EnqueueDeque_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new LinkedQueue<string>();
        var element = "some value";

        // Act
        queue.Enqueue(element);
        var elementFromQueue = queue.Dequeue();

        // Assert
        Assert.AreEqual(0, queue.Count);
        Assert.AreEqual(element, elementFromQueue);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
            // Arrange
        var queue = new LinkedQueue<int>();

        // Act
        queue.Dequeue();

        // Assert: expect and exception
    }

    [TestMethod]
    public void EnqueueDequeue100Elements_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new LinkedQueue<int>();
        int numberOfElements = 1000;

        // Act
        for (int i = 0; i < numberOfElements; i++)
        {
            queue.Enqueue(i);
        }

        // Assert
        for (int i = 0; i < numberOfElements; i++)
        {
            Assert.AreEqual(numberOfElements - i, queue.Count);
            var element = queue.Dequeue();
            Assert.AreEqual(i, element);
            Assert.AreEqual(numberOfElements - i - 1, queue.Count);
        }
    }

    [TestMethod]
    public void CircularQueue_EnqueueDequeueManyChunks_ShouldWorkCorrectly()
    {
        // Arrange
        var queue = new LinkedQueue<int>();
        int chunks = 100;

        // Act & Assert in a loop
        int value = 1;
        for (int i = 0; i < chunks; i++)
        {
            Assert.AreEqual(0, queue.Count);
            var chunkSize = i + 1;
            for (int counter = 0; counter < chunkSize; counter++)
            {
                Assert.AreEqual(value - 1, queue.Count);
                queue.Enqueue(value);
                Assert.AreEqual(value, queue.Count);
                value++;
            }
            for (int counter = 0; counter < chunkSize; counter++)
            {
                value--;
                Assert.AreEqual(value, queue.Count);
                queue.Dequeue();
                Assert.AreEqual(value - 1, queue.Count);
            }
            Assert.AreEqual(0, queue.Count);
        }
    }

    [TestMethod]
    public void Enqueue500Elements_ToArray_ShouldWorkCorrectly()
    {
        // Arrange
        var array = Enumerable.Range(1, 500).ToArray();
        var queue = new LinkedQueue<int>();

        // Act
        for (int i = 0; i < array.Length; i++)
        {
            queue.Enqueue(array[i]);
        }
        var arrayFromQueue = queue.ToArray();

        // Assert
        CollectionAssert.AreEqual(array, arrayFromQueue);
    }
}