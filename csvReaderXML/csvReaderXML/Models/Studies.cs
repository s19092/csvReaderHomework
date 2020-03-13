using System;
using System.Collections.Generic;
using System.Text;

namespace csvReaderXML.Models
{
    public class Studies
    {

        public string name { get; set; }
        public string mode { get; set; }

        public Studies(String name,String mode)
        {
            String tmpMode = " " + mode;
            String tmp = name;
            int index = tmp.ToUpper().IndexOf(tmpMode.ToUpper());
            Console.WriteLine(name + " i " + index);
            if (index >= 0)
            {
                try
                {
                    name = name.Remove(index,tmpMode.Length);
                }
                catch (ArgumentOutOfRangeException e)
                {

                    name = name.Remove(index,tmpMode.Length);

                }
            }
            this.name = name;

            this.mode = mode;
        }
        public Studies() { }
        public override String ToString()
        {

            return name + " " + mode;

        }
        


    }
}
