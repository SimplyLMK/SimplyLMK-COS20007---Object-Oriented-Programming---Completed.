
namespace Swin_ADV
{
    public class LookCommandTest
    {
        Player player, test;
        Bag bag;
        Command inspect;

        Item pc = new Item(new string[] { "pc" }, "a pc", "A sophisticated personal computer");
      

        [SetUp]
        public void Setup()
        {
            inspect = new Look_Command();
            test = new Player("Kha", "Stone age Frogrammer");
            player = new Player("Kha", "Mighty Frogrammer"); 
            bag = new Bag(new string[] { "bag" },"backpack",$"This is {player.FirstId} backpack"); 
            player.Inventory.Put(bag);

        }

        [Test]
        public void Test_Look_At_Me()
        {
            string expecDesc = inspect.Execute(player, new string[] { "look", "at", "inventory" });
            string desc = $"{player.Full_Description}";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Look_At_Pc()
        {
            player.Inventory.Put(pc);

            string expecDesc = inspect.Execute(player, new string[] { "look", "at", "pc" });
            string desc = $"{pc.Full_Description}";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Look_At_Unk()
        {
            string expecDesc = inspect.Execute(player, new string[] { "look", "at", "pc" });
            string desc = "pc not found ";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Look_At_Pc_In_No_Bag()
        {
            bag.Inventory.Put(pc);
            test.Inventory.Put(bag);
            string expecDesc = inspect.Execute(test, new string[] { "look", "at", "pc", "in", $"{player.FirstId}" });
            string desc = $"pc not found ";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Look_At_Pc_In_Me()
        {
            player.Inventory.Put(pc);
            string expecDesc = inspect.Execute(player, new string[] { "look", "at", "pc", "in", "me" });
            string desc = $"{pc.Full_Description}";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Look_At_Pc_In_Bag()
        {
            bag.Inventory.Put(pc);
            string expecDesc = inspect.Execute(player, new string[] { "look", "at", "pc", "in", "bag" });
            string desc = $"{pc.Full_Description}";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Look_At_No_Pc_In_Bag()
        {
            bag.Inventory.Put(pc);
            string expecDesc = inspect.Execute(player, new string[] { "look", "at", "DDR_16GB", "in", "bag" });
            string desc = "DDR_16GB not found ";
            Assert.AreEqual(desc, expecDesc);
        }

        [Test]
        public void Test_Invalid_Look()
        {
            Assert.AreEqual(inspect.Execute(test, new string[] { "look", "around" }), "Invalid Command");
            Assert.AreEqual(inspect.Execute(test, new string[] { "find", "pc" }), "Invalid Command");
        }

    }
}