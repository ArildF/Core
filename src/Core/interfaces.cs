using System.Collections.Generic;
using System.Windows;

namespace Rogue.Core.UI
{

	public interface IShellWindow
	{
		Window Window { get; }
	}

	public interface IShellViewModel
	{}

	public interface IMainScreen
	{
	}

	public interface IModuleContainer
	{
		IEnumerable<IModule> GetModules();
	}

	public interface IModule
	{
		object TileViewModel { get; }
	}
}
