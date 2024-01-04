using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public class LogYonetim
    {
        ILog _log;
        public LogYonetim(ILog log)
        {
            _log = log; 
        }
       

        public void LogYaz()
        {
            _log.Log();
        }
    }
}
