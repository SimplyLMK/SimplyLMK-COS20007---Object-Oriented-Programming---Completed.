
namespace Swin_ADV
{
    public class PathTest
    {
        Player player  = new Player("Kha", "Might Frogrammer");
        Location chamber1 = new Location("Upstair", "The suspicious attic, frequent crackling noise");
        Location chamber2 = new Location("Downstair", "The ominious basement, occasional faint cries for help");
        Pathing path;

        [SetUp]
        public void Setup()
        {
            path = new Pathing(new string[] { "upstair" }, "Staircase", "Crakling stair case", chamber1, chamber2);
        }

        [Test]
        public void Player_Move_To_Path_Destination()
        {
            player.Location = chamber1;
            chamber1.AddPath(path);
            player.Move_Command(path);
            Location exp = chamber2;
            Location real = player.Location;
            Assert.AreEqual(exp, real);
        }

        [Test]
        public void Player_Leave_Location()
        {
            player.Location = chamber1;
            chamber1.AddPath(path);
            player.Move_Command(path);

            Location exp = chamber2;
            Location real = player.Location;
            Assert.AreEqual(exp, real);
        }

        [Test]
        public void Player_Remain_Same_Location_Invalid()
        {
            player.Location = chamber1;
            chamber1.AddPath(path);
            Pathing invalid_Path = chamber1.Locate("south") as Pathing;
            Location former_loc = player.Location;

            if (invalid_Path != null)
            {
                player.Move_Command(invalid_Path);
            }

            Location exp = former_loc;
            Location real = player.Location;
            Assert.AreEqual(exp, real);
        }

        [Test]
        public void Find_Path()
        {
            player.Location = chamber1;
            path = new Pathing(new string[] { "downstair" }, "Hole", "Deep black hole",chamber1, chamber2);
            chamber1.AddPath(path);

            Game_Object exp = chamber1.Locate("downstair");
            Game_Object real = path;

            Assert.AreEqual(exp, real);
        }
    }
}