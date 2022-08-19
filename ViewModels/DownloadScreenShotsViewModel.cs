using System;
using ReactiveUI;
using System.Reactive;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using AppFoxScreenShotTerm.Helpers;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Drawing;


namespace AppFoxScreenShotTerm.ViewModels
{
    public class DownloadScreenShotsViewModel : ViewModelBase
    {
        public class FilesGridRow
        {
            public string FileName { get; set; } = string.Empty;
            public string FullPath { get; set; } = string.Empty;
        }

        public ObservableCollection<FilesGridRow> filesGrid = new();
        public ObservableCollection<FilesGridRow> FilesGrid
        {
            get => filesGrid; 
            private set => this.RaiseAndSetIfChanged(ref filesGrid, value);
        }

        private static readonly HttpClient client = new HttpClient();

        public DateTimeOffset dateFrom = new DateTimeOffset(DateTime.Now);

        public ObservableCollection<CDNRecord> downloadedScreenShots;

        public ObservableCollection<CDNRecord> DownloadedScreenShots
        {
            get => downloadedScreenShots; 
            private set => this.RaiseAndSetIfChanged(ref downloadedScreenShots, value);
        }

        public DateTimeOffset DateFrom
        {
            get => (DateTimeOffset) dateFrom;
            private set => this.RaiseAndSetIfChanged(ref dateFrom, (DateTimeOffset)value);             
        }       

        public DateTimeOffset dateTo = new DateTimeOffset(DateTime.Now);
        public DateTimeOffset DateTo
        {
            get => (DateTimeOffset)dateTo;
            private set => this.RaiseAndSetIfChanged(ref dateTo, (DateTimeOffset)value);
        }

        public DownloadScreenShotsViewModel()
        {
                        
        }

        public async Task GetScreenShots()
        {
            FilesGrid = new();
            var streamTask = client.GetStreamAsync(
                Params.DOWNLOAD_ADDRESS + "?startDate=" + dateFrom.ToString("yyyy.MM.dd") + "&endDate=" + dateTo.ToString("yyyy.MM.dd")
            );
            var repositories = await JsonSerializer.DeserializeAsync<List<CDNRecord>>(
                await streamTask
            );

            if (repositories is not null)
            {
                foreach (var repo in repositories)
                {
                    try
                    {                        
                        DateTime date = DateTime.Parse(repo.Date);
                        var name = date.ToString("yyyy_MM_dd_hh_mm_ss");

                        byte[] file = Convert.FromBase64String(repo.ScreenShot);
                        string extension = Extensions.GetExtension(file);

                        if(extension.Length > 0)
                        {
                            name += "." + extension;
                        }

                        string fullName = Params.applicationPath + Path.DirectorySeparatorChar + Params.DOWNLOAD_FOLDER + Path.DirectorySeparatorChar + name;

                        using (BinaryWriter bw = new BinaryWriter(File.Open(fullName, FileMode.Create)))
                        {
                            bw.Write(file);
                        }

                        FilesGrid.Add(new FilesGridRow() { 
                            FileName = name,
                            FullPath = fullName
                        });

                        Console.WriteLine(fullName);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    
                    
                }

            }

        }        

    }
}