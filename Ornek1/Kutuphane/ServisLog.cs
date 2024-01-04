using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public class ServisLog : ILog
    {
        public int ServisId { get; set; }

        private int numara;

        public ServisLog(string url)
        {
            ServisId = 1;
            numara = 13;
        }
        public void Log()
        {
            ServisId = 1;
            numara = 15;
        }
    }
}
