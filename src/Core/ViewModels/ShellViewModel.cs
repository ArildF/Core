namespace Rogue.Core.UI.ViewModels
{
	public class ShellViewModel : IShellViewModel
	{
		public ShellViewModel(IMainScreen mainScreen)
		{
			MainContent = mainScreen;
		}

		public IMainScreen MainContent { get; private set; }
	}

}
