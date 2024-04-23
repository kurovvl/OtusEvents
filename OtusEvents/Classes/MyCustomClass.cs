using OtusEvents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusEvents.Classes
{
    public class MyCustomClass : ICustomConvertable
    {
        public int Variable { get; set; }
        public MyCustomClass()
        {
            Variable = new Random().Next(0, 100500);
        }


        public float ConvertToCompare()
        {
            return (float)this.GetHashCode();
        }
    }
}
