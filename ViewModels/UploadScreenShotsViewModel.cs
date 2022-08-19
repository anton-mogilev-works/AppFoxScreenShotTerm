using ReactiveUI;
using System;

namespace AppFoxScreenShotTerm.ViewModels
{
    public class UploadScreenShotsViewModel : ViewModelBase
    {

        public string message = "Message";
        public string Message
        {
            get => message;
            set => this.RaiseAndSetIfChanged(ref message, value);
        }

        public UploadScreenShotsViewModel()
        {

        }

        public UploadScreenShotsViewModel(string message)
        {
            Message = message;
            
        }
    }
}