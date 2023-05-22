namespace Swin_ADV
{
    public class Look_Command : Command
    {
        public Look_Command() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player player, string[] order)
        {
            I_Have_Inventory cont = null;
            string itemId = null;
            string invalid = "Invalid Command";

            if (order[0].ToLowerInvariant() != "look")
            {
                return invalid;
            }

            if (order.Length == 3 && order[1].ToLowerInvariant() != "at")
            {
                return "Look at?..";
            }
            else if (order.Length == 3)
            {
                cont = player;
                itemId = order[2];
            }
            else if (order.Length == 5)
            {
                cont = Fetchcont(player, order[4]);
                if (cont == null)
                {
                    return $"{order[4]} not found" ;
                }
                itemId = order[2];
            }
            else
            {
                return invalid;
            }

            return LookAtIn(itemId, cont);
        }

        private I_Have_Inventory Fetchcont(Player player, string contId)
        {
            return player.Locate(contId) as I_Have_Inventory;
        }

        private string LookAtIn(string A_ID, I_Have_Inventory cont)
        {
            if (cont.Locate(A_ID) != null)
            {
                return cont.Locate(A_ID).Full_Description;
            }

            return $"{A_ID} not found " ;
        }
    }
}
