using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using ReactiveUI;
using AppFoxScreenShotTerm.Helpers;

namespace AppFoxScreenShotTerm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // public string messageText = Params.applicationPath + Path.DirectorySeparatorChar + Params.SCREENS_FOLDER + Path.DirectorySeparatorChar + "2022_08_18_11_45_09.jpg";
        // public string MessageText
        // {
        //     get => messageText;
        //     set => this.RaiseAndSetIfChanged(ref messageText, value);
        // }

        public ViewModelBase mainPanelViewModel = new ViewModelBase();

        public ViewModelBase MainPanelViewModel
        {
            get => mainPanelViewModel;
            private set => this.RaiseAndSetIfChanged(ref mainPanelViewModel, value);
        }

        public MainWindowViewModel() 
        {
            MainPanelViewModel = new UploadScreenShotsViewModel();            
        }
        
        // public string imageSource = Params.SCREENS_FOLDER + Path.DirectorySeparatorChar + "2022_08_18_11_45_09.jpg";

        // public ViewModelBase downloadScreenshotsModel;
        
        public void DownloadScreenshots()
        {
            MainPanelViewModel = new DownloadScreenShotsViewModel();
        }



        private void ShowScreenshotsList()
        {
            List<string> screenShots = ScreenShotsHandler.GetScreenshotsList();

            if (screenShots.Count > 0)
            {
                foreach (string screenShot in screenShots)
                {                   
                    // MessageText += screenShot + "\r\n";
                }
            }

        }

        public void MakeScreenshot()
        {
            string imagePath = Params.SCREENS_FOLDER + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".jpg";            

            var captureBmp = new Bitmap(Params.screenWidth, Params.screenHeight, PixelFormat.Format32bppArgb);
            using var captureGraphic = Graphics.FromImage(captureBmp);
            captureGraphic.CopyFromScreen(0, 0, 0, 0, captureBmp.Size);
            try
            {
                captureBmp.Save(imagePath, ImageFormat.Jpeg);
                // MessageText += imagePath + "\r\n";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            

        }
        
    }
}
