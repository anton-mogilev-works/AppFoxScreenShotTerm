using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppFoxScreenShotTerm.Helpers
{
    internal class ScreenShotsHandler
    {
        public static List<string> GetScreenshotsList()
        {
            List<string> screenShots = new();

            string[] fileEntries = Directory.GetFiles(Params.SCREENS_FOLDER);

            foreach (string fileEntry in fileEntries)
            {
                screenShots.Add(fileEntry);
            }

            return screenShots;
        }
    }
}
