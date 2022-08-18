using System;
using ReactiveUI;

namespace AppFoxScreenShotTerm.ViewModels
{
    public class DownloadScreenShotsViewModel : ViewModelBase
    {
        public DateTimeOffset dateFrom = new DateTimeOffset(DateTime.Now);

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

        public string text = "44444444444";

        public string Text
        {
            get => text;
            private set => this.RaiseAndSetIfChanged(ref text, value);
        }

    }
}