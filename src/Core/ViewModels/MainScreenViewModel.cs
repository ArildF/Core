using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Xaml;
using Rogue.Core.UI.Infrastructure;

namespace Rogue.Core.UI.ViewModels
{
	public class MainScreenViewModel : IMainScreen
	{
		public MainScreenViewModel(IMessageBus bus)
		{
			ModuleTileViewModels = new ReactiveCollection<object>();

			bus.Listen<ModuleLoadedMessage>().SubscribeUI(mle => ModuleTileViewModels.Add(mle.Module.TileViewModel));

			NavigateCommand = new ReactiveCommand();

			bus.RegisterMessageSource(NavigateCommand.OfType<IModule>().Select(m => new NavigateMainModuleMessage(m)));
		}

		public ReactiveCommand NavigateCommand { get; private set; }

		public ReactiveCollection<object> ModuleTileViewModels { get; internal set; }
	}

}
