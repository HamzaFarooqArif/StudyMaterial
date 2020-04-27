using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace FYPDesktopApp
{
    class SerialUtility
    {
        private static SerialUtility _instance;
        private SerialUtility()
        {

        }
        public static SerialUtility getInstance()
        {
            if (_instance == null) _instance = new SerialUtility();
            return _instance;
        }

        public List<String> getPortNames()
        {
            return SerialPort.GetPortNames().ToList();
        }
    }
}
