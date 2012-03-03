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
}
