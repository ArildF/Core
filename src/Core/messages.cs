namespace Rogue.Core.UI
{
	public class ModuleLoadedMessage
	{
		public ModuleLoadedMessage(IModule module)
		{
			Module = module;
		}

		public IModule Module { get; private set; }
	}

	public class ApplicationLoadedMessage{}

	public class NavigateMainModuleMessage
	{
		public IModule Module { get; private set; }

		public NavigateMainModuleMessage(IModule module)
		{
			Module = module;
		}
	}
}
