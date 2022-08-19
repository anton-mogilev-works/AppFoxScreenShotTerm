using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using ReactiveUI;
using AppFoxScreenShotTerm.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

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
            var mpvm = new UploadScreenShotsViewModel();            

            MainPanelViewModel = mpvm;
        }
        
        public void DownloadScreenshots()
        {
            MainPanelViewModel = new DownloadScreenShotsViewModel();
        }

        public async Task MakeScreenshot()
        {
            string fileName = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".jpg";
            string imagePath = Params.SCREENS_FOLDER + Path.DirectorySeparatorChar + fileName;            

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
            
            if(File.Exists(imagePath))
            {                  
                HttpContent bytesContent = new ByteArrayContent(File.ReadAllBytes(imagePath));
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    
                    formData.Add(bytesContent, "file", fileName);                   
                    var streamTask = await client.PostAsync(Params.UPLOAD_ADDRESS, formData);
                    await streamTask.Content.ReadAsStringAsync();

                    if (streamTask.IsSuccessStatusCode)
                    {
                        MainPanelViewModel = new UploadScreenShotsViewModel("Screenshot posted");
                    }
                    else
                    {
                        MainPanelViewModel = new UploadScreenShotsViewModel("Error: " + streamTask.StatusCode + "\r\n" + Params.UPLOAD_ADDRESS);
                    }

                    

                    //return streamTask;

                    //var response = await client.PostAsync(actionUrl, formData);
                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    return null;
                    //}
                    //return await response.Content.ReadAsStreamAsync();
                }
            }

        }
        
    }
}
