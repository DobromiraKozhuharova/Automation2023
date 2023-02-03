using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            Collection<int> coll = new Collection<int>();

            Assert.That(coll.Count, Is.EqualTo(0));
            Assert.That(0, Is.EqualTo(coll.Count));
            Assert.That(16, Is.EqualTo(coll.Capacity));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var coll = new Collection<int>(5);
            Assert.That(coll[0], Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5, 10, 15);
            Assert.That(coll.ToString(), Is.EqualTo("[5, 10, 15]"));
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(5, 6);

            Assert.That(coll.Count, Is.EqualTo(2));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }


        [Test]
        public void Test_Collection_Add()
        {
            var coll = new Collection<string>("Tom", "Jerry");

            coll.Add("Spike");

            Assert.AreEqual(coll.ToString(), "[Tom, Jerry, Spike]");
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var coll = new Collection<int>();

            int expectedCount = 10;

            for (int i = 0; i < expectedCount; i++)
            {
                coll.Add(i);
            }

            Assert.That(expectedCount, Is.EqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var coll = new Collection<int>();
            int[] arrayToAdd = new int[] { 1, 2, 3 };

            coll.AddRange(arrayToAdd);

            Assert.That(coll.Count, Is.EqualTo(arrayToAdd.Length),
                "The count of the collection should match the length of the array that was added.");

            for (int i = 0; i < arrayToAdd.Length; i++)
            {
                Assert.That(coll[i], Is.EqualTo(arrayToAdd[i]),
                    $"The value at index {i} should match the value from the array that was added.");
            }
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var coll = new Collection<int>(5, 8, 10);

            int actual = coll[1];
            int expected = 8;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("Tom", "Jerry");

            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Tom, Jerry]"));

        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var coll = new Collection<int>(5, 8, 10);
            coll[1] = 333;

            Assert.That(coll[1], Is.EqualTo(333));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var names = new Collection<string>("Tom", "Jerry");

            Assert.That(() => { var item = names[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var coll = new Collection<int>();
            int oldCapacity = coll.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            coll.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(coll.ToString(), Is.EqualTo(expectedNums));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            int itemToInsert = 10;
            int expectedCount = 3;

            collection.InsertAt(0, itemToInsert);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(collection[0], Is.EqualTo(itemToInsert));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            int itemToInsert = 10;
            int expectedCount = 3;

            collection.InsertAt(collection.Count, itemToInsert);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(collection[collection.Count - 1], Is.EqualTo(itemToInsert));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            int itemToInsert = 10;
            int expectedCount = 3;

            collection.InsertAt(1, itemToInsert);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(collection[1], Is.EqualTo(itemToInsert));
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            Collection<int> collection = new Collection<int>();

            Assert.That(collection.Capacity, Is.EqualTo(16));

            int itemToInsert = 20;

            for (int i = 1; i <= itemToInsert; i++)
            {
                collection.Add(i);
            }

            Assert.That(collection.Count, Is.EqualTo(itemToInsert));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            int itemToInsert = 10;
            int expectedCount = 2;

            Assert.That(() => collection.InsertAt(-1, itemToInsert),
               Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => collection.InsertAt(collection.Count + 1, itemToInsert),
               Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            int expectedCount = 3;

            collection.Exchange(0, 2);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(collection[0], Is.EqualTo(3));
            Assert.That(collection[2], Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            int expectedCount = 2;

            collection.Exchange(0, 1);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(collection[0], Is.EqualTo(2));
            Assert.That(collection[1], Is.EqualTo(1));
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            int expectedCount = 2;

            Assert.That(() => collection.Exchange(-1, 1),
               Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => collection.Exchange(0, collection.Count),
               Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => collection.Exchange(collection.Count, 0),
               Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => collection.Exchange(collection.Count + 1, 0),
               Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            Collection<int> collection = new Collection<int>();

            collection.AddRange(new[] { 1, 2, 3 });

            int expectedCount = 2;

            var removedItem = collection.RemoveAt(0);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(removedItem, Is.EqualTo(1));
            Assert.That(collection[0], Is.EqualTo(2));
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            Collection<int> collection = new Collection<int>();

            collection.AddRange(new[] { 1, 2, 3 });

            int expectedCount = 2;

            var removedItem = collection.RemoveAt(collection.Count - 1);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(removedItem, Is.EqualTo(3));
            Assert.That(collection[collection.Count - 1], Is.EqualTo(2));
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle() 
        {
            Collection<int> collection = new Collection<int>();

            collection.AddRange(new[] { 1, 2, 3 });

            int expectedCount = 2;

            var removedItem = collection.RemoveAt(1);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
            Assert.That(removedItem, Is.EqualTo(2));
            Assert.That(collection[1], Is.EqualTo(3));
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            Collection<int> collection = new Collection<int>();

            collection.AddRange(new[] { 1, 2 });

            int expectedCount = 2;
            
            Assert.That(() => collection.RemoveAt(-1),
              Throws.InstanceOf<ArgumentOutOfRangeException>());            

            Assert.That(() => collection.RemoveAt(collection.Count), 
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => collection.RemoveAt(collection.Count + 1), 
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_Collection_RemoveAll() 
        {
            Collection<int> collection = new Collection<int>();

            collection.AddRange(new[] { 1, 2, 3 });

            int expectedCount = 0;

            collection.RemoveAt(0);
            collection.RemoveAt(0);
            collection.RemoveAt(0);

            Assert.That(collection.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_Collection_Clear() 
        {
            Collection<int> collection = new Collection<int>();

            collection.AddRange(new[] { 1, 2, 3 });

            int expectedCount = 0;

            collection.Clear();

            Assert.That(collection.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Collection_ToStringEmpty() 
        {
            Collection<int> collection = new Collection<int>();

            string result = collection.ToString();

            Assert.That(result, Is.EqualTo("[]"), 
                "The ToString method should return an empty bracket for an empty collection.");
        }

        [Test]
        public void Test_Collection_ToStringSingle() 
        {
            Collection<int> collection = new Collection<int>(new int[] { 1 });

            string result = collection.ToString();

            Assert.That(result, Is.EqualTo("[1]"), 
                "The ToString method should return the correct string representation for a single item collection.");
        }

        [Test]
        public void Test_Collection_ToStringMultiple() 
        {
            Collection<int> collection = new Collection<int>(new int[] { 1, 2, 3, 4, 5 });

            string result = collection.ToString();

            Assert.That(result, Is.EqualTo("[1, 2, 3, 4, 5]"), 
                "The ToString method should return the correct string representation for a collection with multiple items.");
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections() 
        {
            Collection<Collection<int>> collection = new Collection<Collection<int>>();
            collection.Add(new Collection<int>(new int[] { 1, 2, 3 }));
            collection.Add(new Collection<int>(new int[] { 4, 5 }));

            string result = collection.ToString();

            Assert.That(result, Is.EqualTo("[[1, 2, 3], [4, 5]]"), 
                "The ToString method should return the correct string representation for a collection with nested collections.");
        }

        [Test]
        [Timeout(1000)]

        public void Test_Collection_1MillionItems() 
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);

        }

    }
}