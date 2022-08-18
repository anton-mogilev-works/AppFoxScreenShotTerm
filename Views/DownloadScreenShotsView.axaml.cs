using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AppFoxScreenShotTerm.Views
{
    public partial class DownloadScreenShotsView : UserControl
    {
        public DownloadScreenShotsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}