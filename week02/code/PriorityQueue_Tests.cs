using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: No exception was thrown before fix.
    public void TestPriorityQueue_Empty()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single element and then dequeue it.
    // Expected Result: The dequeued value should be the same as the enqueued value.
    // Defect(s) Found: No defects found.
    public void TestPriorityQueue_SingleElement()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);

        var value = queue.Dequeue();
        Assert.AreEqual("A", value);
    }

    [TestMethod]
    // Scenario: Enqueue multiple elements with different priorities and then dequeue them.
    // Expected Result: The dequeued values should be in the order of their priorities (highest to lowest).
    // Defect(s) Found: The dequeued values were not in the correct order before fix.
    public void TestPriorityQueue_MultipleElements()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);

        var value1 = queue.Dequeue();
        Assert.AreEqual("B", value1);

        var value2 = queue.Dequeue();
        Assert.AreEqual("C", value2);

        var value3 = queue.Dequeue();
        Assert.AreEqual("A", value3);
    }

    [TestMethod]
    // Scenario: Enqueue multiple elements with the same highest priority and then dequeue them.
    // Expected Result: The dequeued values should be in FIFO order.
    // Defect(s) Found: The dequeued values were not in FIFO order before fix.
    public void TestPriorityQueue_MultipleElementsSamePriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 3);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);

        var value1 = queue.Dequeue();
        Assert.AreEqual("A", value1);

        var value2 = queue.Dequeue();
        Assert.AreEqual("B", value2);

        var value3 = queue.Dequeue();
        Assert.AreEqual("C", value3);
    }
}
