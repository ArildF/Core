namespace Rogue.Core.UI.ViewModels
{
	public class WeightTileViewModel : ITileViewModel
	{
		public WeightTileViewModel(IModule module)
		{
			Module = module;
		}

		public IModule Module { get; private set; }
	}
}
