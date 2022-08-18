using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppFoxScreenShotTerm.Helpers
{
    internal class Params
    {
        public static int screenWidth = int.MinValue;
        public static int screenHeight = int.MinValue;
        public const string SCREENS_FOLDER = "screenshots";

        public static string? applicationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    }
}
