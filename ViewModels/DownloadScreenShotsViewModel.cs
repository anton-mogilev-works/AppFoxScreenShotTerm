using System;
using ReactiveUI;

namespace AppFoxScreenShotTerm.ViewModels
{
    public class DownloadScreenShotsViewModel : ViewModelBase
    {
        public DateTime dateFrom = DateTime.Now;

        public DateTime DateFrom
        {
            get => (DateTime) dateFrom;
            private set
            {
                this.RaiseAndSetIfChanged(ref dateFrom, (DateTime) value);
                // Text = dateFrom.ToString();
                Console.WriteLine(dateFrom.ToString("s"));
            } 
        }

        public void DateFromChanged()
        {
            Console.WriteLine("Hello");
        }

        public DateTime dateTo = new DateTime();

        public string text = "44444444444";

        public string Text
        {
            get => text;
            private set => this.RaiseAndSetIfChanged(ref text, value);
        }

    }
}