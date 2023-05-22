using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Game_Object : Identifiable
    {
        private string _description;
        private string _name;

        public Game_Object(string[] ids, string name, string descrip) : base(ids)
        {
            _name = name;
            _description = descrip;
        }

        public string Name
        {
            get
            { 
                return _name; 
            }
        }

        public virtual string Full_Description
        {
            get
            {
                return _description; 
            } 
        }

        public string Short_Description
        {
            get
            {
                return $"{_name} ({FirstId})";
            }
        }



    }
}
