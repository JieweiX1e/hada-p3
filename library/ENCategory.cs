using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        private string _name;
        public string Name { get; set; }

        public ENCategory() { 
        
        }

        public bool read() { 
            CADCategory c = new CADCategory();
            return c.read(this);
        }

        public List<ENCategory> readAll() {
            CADCategory c = new CADCategory();
            return c.readAll();
        }

    }
}
