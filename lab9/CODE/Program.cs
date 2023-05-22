using Swin_ADV;
using System.Numerics;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        string allias = "";
        string desc = "";


        Console.WriteLine("Hark! Brave adventurer, thou hast entered a realm of magic and wonder, a place where dragons soar and wizards weave their spells. Be not afraid, for thou art a hero, destined for greatness and bound for glory. May thy journey be filled with adventure and may the tales of thy deeds echo throughout the ages!");
        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine("Pray, tell me, how shall you address this humble entity before thee? By what title or name shall you hail this master of knowledge and purveyor of wisdom? Speak, and let your words be heard throughout the land!(I mean enter your name)");
        allias = Console.ReadLine();
        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine("What words doth thou bestow upon thyself, as thou endeavor to encapsulate the essence of thy being? In short, how wouldst thou describe thyself, in all thy awesomeness?(I mean enter description)");
        desc = Console.ReadLine();

        Player player = new Player(allias, desc);

        Item pc = new Item(new string[] { "pc" }, "Computer", "=> A PC in fantasy is a mystical tool of creation and destruction, capable of summoning worlds with just a few clicks");
        player.Inventory.Put(pc);

        Item Codex_Umbra_Magnificia = new Item(new string[] { "Codex_Umbra_Magnificia" }, "Forbidden Weapone", "=> The Codex Umbra is a dark and mysterious artifact of great power, whispered to contain ancient knowledge capable of unraveling the very fabric of reality itself.");
        player.Inventory.Put(Codex_Umbra_Magnificia);

        Item pocket_knife = new Item(new string[] { "pocket_knife" }, "A rather dull pocket knife", "The pocket knife could cause initmidation to those who are unarmed, however, it is pratically useless agaisnt well-equipped entity");
        Item rope = new Item(new string[] { "rope" }, "A very down-graded rope", "it has strange some reddish black stain on it");
        Item force_multiplier = new Item(new string[] { "force_multiplier" }, "an artifact capable of smashing doors", "it is said to be able to output a great ammount of pressure on a very small point of contact surface, making it very deadly");

        Bag bag = new Bag(new string[] { "bag" }, "backpack", $"This is {player.FirstId} backpack");



        Location bed = new Location("red bed", "You have just woken up from a strange red bed, it felt really sticky and hard to get out of bed");
        player.Location = bed; 

        Location basement = new Location("downstair basement", "this basement is dark and moist, you caught a glimpse of a silhouette");
        Pathing chamber1 = new Pathing(new string[] { "downstair" }, "hole", "jump down the hole", bed, basement);
        Pathing chamber2 = new Pathing(new string[] { "north" }, "door", "open and move through the door", basement, bed);

        bed.AddPath(chamber1);
        basement.AddPath(chamber2);

        Location upstair = new Location("upstair attic", "you have caught glimpse of that silhouette again, but this time it is dangling from the ceilling");
        Pathing chamber3 = new Pathing(new string[] { "upstair" }, "Stair", "Travel through door", bed, upstair);
        chamber3.Blocked = true;
        chamber3.Unlocked = true;

        Pathing chamber4 = new Pathing(new string[] { "west" }, "Door", "Travel through door", upstair, bed);
        bed.AddPath(chamber3);
        upstair.AddPath(chamber4);



        Item iron_sword = new Item(new string[] { "iron_sword" }, "rusty_Iron_Sword", "=> The Rusty Iron Sword may be weathered, but in the hands of a skilled warrior, it is a weapon of grit and determination, capable of overcoming even the toughest of foes.");
        player.Inventory.Put(bag);
        
        bag.Inventory.Put(pc);
        bag.Inventory.Put(iron_sword);

       

        bed.Inventory.Put(pc);
        bed.Inventory.Put(pocket_knife);
        basement.Inventory.Put(force_multiplier);
        upstair.Inventory.Put(rope);


        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine($"You are given 2 artifacts {pc.Name} and {Codex_Umbra_Magnificia.Name} ");
        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine($"Brace yourself {player.Full_Description}");
        Console.WriteLine($"Within you bag which enhance your capacity, {bag.Full_Description}");

        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");



        var commandProcessor = new CommandProcessor();
        Console.WriteLine("if you are unsure with the command, type {help} or {manual} to recieve instruction");

        

        while (true)
        {
            Console.Write("Enter command: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLowerInvariant() == "quit" || userInput.ToLowerInvariant() == "exit")
            {
                break;
            }
            if(userInput.ToLowerInvariant() == "help" || userInput.ToLowerInvariant() == "manual")
            {
                UserManual.Manual();
            }

            Console.WriteLine(commandProcessor.Execute(userInput, player));
        }




    }
}
