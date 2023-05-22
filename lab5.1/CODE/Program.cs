using Swin_ADV;

class Program
{
    static void Main(string[] args)
    {
   
        Player player = new Player("Kha", " Kha The Mighty Programmer");

        Item pc = new Item(new string[] { "pc" }, "computer", "Personal Computer");
        player.Inventory.Put(pc);

        Item Codex_Umbra_Magnificia = new Item(new string[] { "book" },  "Forbidden Weapone" , "summon shadow");
        player.Inventory.Put(Codex_Umbra_Magnificia);
      
        Console.WriteLine(player.Full_Description);
       

        Game_Object item = player.Locate("pc");

       

        if (item != null)
        {
            Console.WriteLine($"{item.Name } has been found in my inventory " );
        }
        else
        {
            Console.WriteLine("Item has not been found");
        }

        
        item = player.Locate("lotion");
        if (item != null)
        {
            Console.WriteLine($"{item.Name} has been found in my inventory ");
        }
        else
        {
            Console.WriteLine("Item has not been found");
        }

      
        Item taken_Item = player.Inventory.Take("book");
        if (taken_Item != null)
        {
            Console.WriteLine($" { taken_Item.Name} has been taken from inventory");
        }
        else
        {
            Console.WriteLine("Item has not been found in inventory");
        }

        taken_Item = player.Inventory.Take("sword");
        if (taken_Item != null)
        {
            Console.WriteLine($" {taken_Item.Name} has been taken from inventory");
        }
        else
        {
            Console.WriteLine("Item has not been found in inventory");
        }

        Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////");
        
        //Look_Command inspect= new Look_Command();
        //string result = inspect.Execute(player, new string[] { "Look", "at", "pc" });
        //Console.WriteLine(result);
        //result = inspect.Execute(player, new string[] { "look", "at", "pc", "in", "Inventory" });
        //Console.WriteLine(result);


    }
}
