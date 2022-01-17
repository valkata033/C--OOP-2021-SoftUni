using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0)]
        [TestCase(16)]
        [TestCase(1)]
        [TestCase(7)]
        public void AddMethodShouldAddNewElementsWhileCountEquals16(int count)
        {
            Database database = new Database();

            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowsExeptionForMoreThan16Elements()
        {
           Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(5));
        }

        [Test]
        [TestCase(1, 15)]
        [TestCase(1, 11)]
        [TestCase(1, 4)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddAllElementsBelow16(
            int start,
            int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Database database = new Database(elements);

            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 20)]
        public void ConstructorShouldThrowsExeptionForMoreThan16Elements(
           int start,
           int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(
                () => new Database(elements));
        }

        [Test]
        public void RemoveMethodShouldThrowsExeptionWhenArrayIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [Test]
        [TestCase(1, 10, 1, 9)]
        [TestCase(1, 16, 1, 15)]
        public void RemoveMethodShouldDecreaseCountOfArrayWhenRemoveElement(
            int start,
            int count,
            int toRemove,
            int result)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database database = new Database(elements);

            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void FetchShouldReturnAllValidElements()
        {
            Database database = new Database(1, 2, 3);

            database.Add(4);
            database.Add(5);

            database.Remove();
            database.Remove();
            database.Remove();

            int[] fetchData = database.Fetch();

            int[] expected = new int[] { 1, 2 };

            Assert.AreEqual(expected, fetchData);
        }
    }
}