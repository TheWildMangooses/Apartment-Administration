using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class GenericSingleton
    {
        private GenericSingleton()
        {
            //I suppose everything should be 
        }
        private static GenericSingleton _instance;
        private static GenericSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GenericSingleton();
                }
                return _instance;
            }
        }
    }
}
