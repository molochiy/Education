using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAS
{
    public class InfoAboutField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int InfoType { get; set; }
        public bool ISNOTNULL { get; set; }
        public bool ISPRIMERYKEY { get; set; }

        public InfoAboutField(string name, string type, int infotype, bool isnotnull, bool isprimerykey)
        {
            Name = name;
            Type = type;
            InfoType = infotype;
            ISNOTNULL = isnotnull;
            ISPRIMERYKEY = isprimerykey;
        }
    }
}
