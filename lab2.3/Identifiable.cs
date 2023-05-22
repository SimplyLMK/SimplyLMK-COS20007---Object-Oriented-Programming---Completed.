using System.Collections.Generic;

namespace Identifiable_Object
{
    public class Identifiable
    {
      
        private List<string> _identifiers;

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLowerInvariant());
        }

        public Identifiable(string[] idents)
        {
            _identifiers = new List<string>(idents.Length);
            foreach (string id in idents)
            {
                AddIdentifier(id);
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLowerInvariant());
        }

 
        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
       
      
    }
}
