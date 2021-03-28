using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Personel
    {
        public ulong PersonelNo { get; set; }
        public string Department { get; set; }
        public IDInfo IDInformation { get; set; } = new IDInfo(); //composition
    }
}
