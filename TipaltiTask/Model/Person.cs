using System;
using System.Collections.Generic;
using System.Text;

namespace TipaltiTask.Model
{
    class Person
    {
        public Name FullName { get; set; }

        public string Address { get; set; }


        //Assumption: in the example there is only a string address, so turning the Adrees into a string instead on an object!

        //public Address Address { get; set; }
    }
}
