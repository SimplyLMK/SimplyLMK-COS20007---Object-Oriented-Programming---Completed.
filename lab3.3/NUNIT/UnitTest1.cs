using System.Text;

namespace Swin_ADV
{
   
    public class SwinAdventureTests
    {

        private Item _item1;
        private Item _item2;
        private Inventory _inventory;
        private Player _player;

        [SetUp]

        public void Setup()
        {
            _item1 = new Item(new string[] { "key" }, "Key", "A small rusty key.");
            _item2 = new Item(new string[] { "book" }, "Book", "A large heavy book.");
            _inventory = new Inventory();
            _inventory.Put(_item1);
            _player = new Player("John", "A regular guy.");
           _player.Inventory = _inventory;
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_item1.AreYou("key"));
            Assert.IsFalse(_item1.AreYou("book"));
        }

        [Test]
        public void TestItemShortDescription()
        {
            Assert.AreEqual("Key (key)", _item1.Short_Description);
        }

        [Test]
        public void TestItemFullDescription()
        {
            Assert.AreEqual("A small rusty key.", _item1.Full_Description);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(_inventory.Has_Item("key"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(_inventory.Has_Item("book"));
        }

        [Test]
        public void TestFetchItem()
        {
            Item item = _inventory.Fetch("key");
            Assert.AreEqual(_item1, item);
            Assert.IsTrue(_inventory.Has_Item("key"));
        }

        [Test]
        public void TestTakeItem()
        {
            Item item = _inventory.Take("key");
            Assert.AreEqual(_item1, item);
            Assert.IsFalse(_inventory.Has_Item("key"));
        }

        [Test]
        
        public void TestItemList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tKey (key)");
            Assert.AreEqual(sb.ToString(), _inventory.ItemList);
        }


        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
            Assert.IsFalse(_player.AreYou("key"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Game_Object item = _player.Locate("key");
            Assert.AreEqual(_item1, item);
           Assert.IsTrue(_player.Inventory.Has_Item("key"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Game_Object me = _player.Locate("me");
            Assert.AreEqual(_player, me);
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Game_Object nothing = _player.Locate("nothing");
            Assert.IsNull(nothing);
        }

     


    }

}