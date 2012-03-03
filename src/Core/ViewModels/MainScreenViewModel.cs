using ReactiveUI;
using Rogue.Core.UI.Infrastructure;

namespace Rogue.Core.UI.ViewModels
{
	public class MainScreenViewModel : IMainScreen
	{
		public MainScreenViewModel(IMessageBus bus)
		{
			ModuleTileViewModels = new ReactiveCollection<object>();

			bus.Listen<ModuleLoadedMessage>().SubscribeUI(mle => ModuleTileViewModels.Add(mle.Module.TileViewModel));
		}

		public ReactiveCollection<object> ModuleTileViewModels { get; internal set; }
	}
}
