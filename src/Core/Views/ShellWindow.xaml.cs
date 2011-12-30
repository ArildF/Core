using System.Windows.Input;

namespace Rogue.Core.UI.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
