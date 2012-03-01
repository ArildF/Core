namespace Rogue.Core.UI.ViewModels
{
	public class MainScreenViewModel : IMainScreen
	{
		public MainScreenViewModel()
		{
			Modules = new[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven"};
		}

		public string[] Modules { get; internal set; }
	}
}
