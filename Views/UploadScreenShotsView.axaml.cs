using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AppFoxScreenShotTerm.Views
{
    public partial class UploadScreenShotsView : UserControl
    {
        public UploadScreenShotsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}