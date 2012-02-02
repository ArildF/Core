using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Rogue.Core.UI.Views;

namespace Rogue.Core.UI
{
	public class FooBar
	{
		
	}
	class Bootstrapper
	{
		private readonly IWindsorContainer _container;

		public Bootstrapper()
		{
			_container = new WindsorContainer();
		}

		public IShellWindow BootStrap()
		{
			_container.Install(FromAssembly.This());

			_container.Register(Component.For<IShellWindow>().ImplementedBy<ShellWindow>());

			return _container.Resolve<IShellWindow>();

		}
	}

}
