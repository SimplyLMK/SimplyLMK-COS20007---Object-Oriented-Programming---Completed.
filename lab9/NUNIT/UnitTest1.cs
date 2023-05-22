
namespace Swin_ADV
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor _commandProcessor;
        private Player player;
        private Location destination;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            _commandProcessor = new CommandProcessor();

  
            player = new Player("Kha", "The mighty Frogrammer");

            Item pc = new Item(new string[] { "pc" }, "Computer", "A personal Computer");
            player.Inventory.Put(pc);

            Location start = new Location("start", "Starting point");
            destination = new Location("destination", "Destination"); // Remove the declaration here
            Pathing path = new Pathing(new string[] { "north" }, "path", "A path to the north", start, destination);

            start.AddPath(path);
            player.Location = start;

            bag = new Bag(new string[] { "bag" }, "Bag", "A useful bag");
            player.Inventory.Put(bag);
        }

        [Test]
        public void Look_CommandTest()
        {
            string result = _commandProcessor.Execute("look at pc", player);
            Assert.AreEqual("A personal Computer", result);
        }

        [Test]
        public void Move_CommandTest()
        {
            string result = _commandProcessor.Execute("move north", player);
            Assert.AreEqual($"You followed to the north going through path and reaching the destination\n\n{destination.Full_Description} ", result);
            Assert.AreEqual(destination, player.Location);
        }

        [Test]
        public void Take_CommandTest()
        {

            Item gem = new Item(new string[] { "gem" }, "Gem", "A shiny gemstone");
            player.Location.Inventory.Put(gem);
            string result = _commandProcessor.Execute("take gem", player);
            Assert.AreEqual("You have taken Gem.", result);
            Assert.IsTrue(player.Inventory.Has_Item("gem"));
        }

        [Test]
        public void Use_CommandTest()
        {

            Location startingLocation = new Location("start", "Starting location");
            Location blockedLocation = new Location("blocked", "Blocked location");
            Pathing blockedPath = new Pathing(new string[] { "east" }, "east", "Blocked path", startingLocation, blockedLocation, true);
            blockedPath.Unlocked = true;
            startingLocation.AddPath(blockedPath);
            player.Location = startingLocation;

            Item force_Multiplier = new Item(new string[] { "force_multiplier" }, "Force Multiplier", "An artifact capable of smashing doors");
            player.Inventory.Put(force_Multiplier);

            string result = _commandProcessor.Execute("use force_multiplier east", player);
            Assert.AreEqual("You have successfully used force_multiplier to unblock the east door.", result);
            Assert.IsFalse(blockedPath.Blocked);

            result = _commandProcessor.Execute("use force_multiplier east", player);
            Assert.AreEqual("The east door is not blocked. No need to use force_multiplier.", result);
        }




    }
}