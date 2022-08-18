using Avalonia.Controls;
using System;
using System.Text;
using AppFoxScreenShotTerm.Helpers;

namespace AppFoxScreenShotTerm.Views
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();            

            Params.screenWidth = this.Screens.Primary.Bounds.Width;
            Params.screenHeight = this.Screens.Primary.Bounds.Height;

        }
    }
}
