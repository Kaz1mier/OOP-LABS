using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
   
        public class EditField
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public EditField(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    

}
