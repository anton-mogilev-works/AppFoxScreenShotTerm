using System.Linq;

namespace AppFoxScreenShotTerm.Helpers
{
    public class Extensions
    {
        private static readonly byte[] BMP = { 66, 77 };       
        private static readonly byte[] GIF = { 71, 73, 70, 56 };
        private static readonly byte[] ICO = { 0, 0, 1, 0 };
        private static readonly byte[] JPG = { 255, 216, 255 };
        private static readonly byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
        

        public static string GetExtension(byte[] file)
        {
            string extension = string.Empty;

            //Get the MIME Type
            if (file.Take(2).SequenceEqual(BMP))
            {
                extension = "bmp";
            }          
            else if (file.Take(4).SequenceEqual(GIF))
            {
                extension = "gif";
            }
            else if (file.Take(4).SequenceEqual(ICO))
            {
                extension = "ico";
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                extension = "jpg";
            }
            
            else if (file.Take(16).SequenceEqual(PNG))
            {
                extension = "png";
            }
           
            return extension;
        }
    }
}
