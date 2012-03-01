using System;
using System.Windows;
using System.Windows.Input;

namespace Rogue.Core.UI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : IShellWindow
    {
        private ShellView()
        {
            InitializeComponent();
        }

    	public ShellView(IShellViewModel model) : this()
    	{
    		DataContext = model;
    	}


    	private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    	public Window Window
    	{
    		get { return this; }
    	}
    }
}
