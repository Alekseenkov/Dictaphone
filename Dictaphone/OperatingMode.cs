using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictaphone
{
    static class OperatingMode
    {
        public static bool isModeDictaphone { get; set; } = false;  // переменная состояние диктафона true(обычный режим)
        public static bool charging { get; set; } = false; //идет ли зарядка 
        public static int chargePercent{ get; set; } = 40;//  переменная заряда батареи 
        public static int isModeDictaphoneTime { get; set; } = 0;

    }
}
