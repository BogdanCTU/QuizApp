using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    class GlobalUtilities
    {
        /// <summary>
        /// Global variables taht can be accesed from every class
        /// </summary>
        public static bool TraceOpened = false, FileOpened = false;
        public static int ID_User = -1, LastQuest = 2;
    }
}
