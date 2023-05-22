using Swin_ADV;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string allias = "";
        string desc = "";

        
        Console.WriteLine("Hark! Brave adventurer, thou hast entered a realm of magic and wonder, a place where dragons soar and wizards weave their spells. Be not afraid, for thou art a hero, destined for greatness and bound for glory. May thy journey be filled with adventure and may the tales of thy deeds echo throughout the ages!");
        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine("Pray, tell me, how shall you address this humble entity before thee? By what title or name shall you hail this master of knowledge and purveyor of wisdom? Speak, and let your words be heard throughout the land!(I mean enter your name)");
        allias= Console.ReadLine();
        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine("What words doth thou bestow upon thyself, as thou endeavor to encapsulate the essence of thy being? In short, how wouldst thou describe thyself, in all thy awesomeness?(I mean enter description)");
        desc= Console.ReadLine();

        Player player = new Player(allias, desc);

        Item pc = new Item(new string[] { "pc" }, "Computer", "=> A PC in fantasy is a mystical tool of creation and destruction, capable of summoning worlds with just a few clicks");
        player.Inventory.Put(pc);

        Item Codex_Umbra_Magnificia = new Item(new string[] { "Codex_Umbra_Magnificia" },  "Forbidden Weapone" , "=> The Codex Umbra is a dark and mysterious artifact of great power, whispered to contain ancient knowledge capable of unraveling the very fabric of reality itself.");
        player.Inventory.Put(Codex_Umbra_Magnificia);

        Bag bag = new Bag(new string[] { "bag" }, "backpack", $"This is {player.FirstId} backpack");

        Item iron_sword = new Item(new string[] {"iron_sword"}, "rusty_Iron_Sword", "=> The Rusty Iron Sword may be weathered, but in the hands of a skilled warrior, it is a weapon of grit and determination, capable of overcoming even the toughest of foes.");
        player.Inventory.Put(bag);
        bag.Inventory.Put(pc);
        bag.Inventory.Put(iron_sword);

        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine($"You are given 2 artifacts {pc.Name} and {Codex_Umbra_Magnificia.Name} ");
        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");
        Console.WriteLine($"Brace yourself {player.Full_Description}");
        Console.WriteLine($"Within you bag which enhance your capacity, {bag.Full_Description}");

        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t*****\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n");

        string command;
        Command inspect = new Look_Command();
        StringBuilder fix = new StringBuilder();

        do
        {
            Console.Write("Enter command: ");
            command = Console.ReadLine();
            fix.Clear().Append(command);

            List<string> list = new List<string>();
            string str = string.Empty;

            for (int i = 0; i < fix.Length; i++)
            {
                if (fix[i] == ' ')
                {
                    list.Add(str);
                    str = string.Empty;
                }
                else
                {
                    str += fix[i];
                }
            }

            if (str != string.Empty)
            {
                list.Add(str);
            }

            Console.WriteLine(inspect.Execute(player, list.ToArray()));
        } while (command != "exit");



    }
}
