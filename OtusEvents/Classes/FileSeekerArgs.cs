using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusEvents.Classes
{
    public class FileSeekerArgs : EventArgs
    {
        public string FileName {  get; set; }
        public bool Cancel { get; set; }
    }
}
