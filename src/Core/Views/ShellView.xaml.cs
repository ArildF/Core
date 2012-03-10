using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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

    	private void ShellView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    	{

    		if (e.ChangedButton == MouseButton.Left)
    		{
    			TextFormattingMode current = TextOptions.GetTextFormattingMode(this);
    			SetValue(TextOptions.TextFormattingModeProperty,
    			         current == TextFormattingMode.Display ? TextFormattingMode.Ideal : TextFormattingMode.Display);
    		}
			else if (e.ChangedButton == MouseButton.Right)
			{
				TextRenderingMode current = TextOptions.GetTextRenderingMode(this);
				TextRenderingMode newMode = current == TextRenderingMode.ClearType
				                            	? TextRenderingMode.Auto
				                            	: (TextRenderingMode) ((int) ++current);
				TextOptions.SetTextRenderingMode(this, newMode);

			}
    	}
    }
}
