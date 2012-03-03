using System;
using System.Windows;
using System.Windows.Input;
using ReactiveUI;

namespace Rogue.Core.UI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : IShellWindow
    {
    	private readonly IMessageBus _bus;

    	private ShellView()
        {
            InitializeComponent();
        }

    	public ShellView(IShellViewModel model, IMessageBus bus) : this()
    	{
    		_bus = bus;
    		DataContext = model;

			Loaded += OnLoaded;
    	}

    	private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    	{
    		_bus.SendMessage<ApplicationLoadedMessage>(null);
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
