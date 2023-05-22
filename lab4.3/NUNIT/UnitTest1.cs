using System.Text;

namespace Swin_ADV
{

    [TestFixture]
    class BagTests
    {
        private Bag _bag1;
        private Bag _bag2;
        private Item _item1;
        private Item _item2;

    [SetUp]
        public void SetUp()
        {
            _bag1 = new Bag(new string[] { "bag1", "bag" }, "Bag 1", "A bag for testing");
            _bag2 = new Bag(new string[] { "bag2", "bag" }, "Bag 2", "A bag for testing");
            _item1 = new Item(new string[] { "item1", "item" }, "Item 1", "An item for testing");
            _item2 = new Item(new string[] { "item2", "item" }, "Item 2", "An item for testing");
            _bag1.Inventory.Put(_item1);
            _bag2.Inventory.Put(_item2);
            _bag1.Inventory.Put(_bag2);

        }

    [Test]
        public void TestBagLocatesItems()
        {
            string itemId = "item1";
            string expectedDesc = "Item 1 (item1)";

            Item item = (Item)_bag1.Locate(itemId);

            Assert.IsNotNull(item);
            Assert.AreEqual(expectedDesc, item.Short_Description);
            Assert.IsTrue(_bag1.Inventory.Has_Item(itemId));
    }

    [Test]
        public void TestBagLocatesItself()
        {
            string bagId = "bag1";

            Game_Object obj = _bag1.Locate(bagId);

            Assert.IsNotNull(obj);
            Assert.AreEqual(_bag1, obj);
    }

    [Test]
        public void TestBagLocatesNothing()
        {
            string invalidId = "invalid";

            Game_Object obj = _bag1.Locate(invalidId);

            Assert.IsNull(obj);
        }
    
        [Test]

        public void TestBagFullDescription()
        {
            string expectedDesc = "Bag 1 (bag1)\r\nA bag for testing\r\nIn the Bag 1 you can see:\r\n\tItem 1 (item1)\r\n\tBag 2 (bag2)\r\n";
            string desc = _bag1.Full_Description;
            Console.WriteLine("Expected Output:"); // debug attempted, issue fixed
            Console.WriteLine(expectedDesc);
            Console.WriteLine("Actual Output:"); // debug attempted, issue fixed
            Console.WriteLine(desc);
            Assert.AreEqual(expectedDesc, desc);
        }

        [Test]

        public void TestBagInBag()
        {
            _bag1.Inventory.Put(_item1);
            Assert.That(_bag1.Locate("Bag1"), Is.EqualTo(_bag1));

        }
    }
}