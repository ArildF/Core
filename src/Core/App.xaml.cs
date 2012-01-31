using System.Windows;

namespace Rogue.Core.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var bootstrapper = new Bootstrapper();

			var window = bootstrapper.BootStrap();

			Application.Current.MainWindow = window.Window;

			window.Window.Show();
		}
	}
}
