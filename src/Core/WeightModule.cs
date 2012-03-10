using Rogue.Core.UI.ViewModels;

namespace Rogue.Core.UI
{
	public class WeightModule : IModule
	{
		public WeightModule(WeightTileViewModel vm)
		{
			TileViewModel = vm;
		}

		public object TileViewModel { get; private set; }
	}
}
