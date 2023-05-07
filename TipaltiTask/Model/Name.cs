using System;
using System.Collections.Generic;
using System.Text;

namespace TipaltiTask.Model
{
    class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
