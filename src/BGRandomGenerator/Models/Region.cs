using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGRandomGenerator.Utility
{
    public class Region
    {
        public string Name { get; set; }       

        public int MinCode { get; set; }

        public int MaxCode { get; set; }

        public Region(string name, int minCode, int maxCode)
        {
            Name = name;            
            MinCode = minCode;
            MaxCode = maxCode;
        }
    }
}
