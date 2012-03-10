using Rogue.Core.UI.ViewModels;

namespace Rogue.Core.UI
{
	public class WeightModule : IModule
	{
		private readonly WeightTileViewModel _tileViewModel;

		public WeightModule()
		{
			_tileViewModel = new WeightTileViewModel(this);
			MainViewModel = new WeightMainScreenViewModel();
		}

		public ITileViewModel TileViewModel { get { return _tileViewModel; } }

		public object MainViewModel { get; private set; }
	}
}
