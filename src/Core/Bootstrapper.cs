using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Rogue.Core.UI.Infrastructure;
using Rogue.Core.UI.ViewModels;
using Rogue.Core.UI.Views;

namespace Rogue.Core.UI
{
	class Bootstrapper
	{
		private readonly IWindsorContainer _container;

		public Bootstrapper()
		{
			_container = new WindsorContainer();
		}

		public IShellWindow BootStrap()
		{
			_container.AddFacility(new ViewModelRegistrationFacility(Application.Current));
			_container.Install(FromAssembly.This());

			_container.Register(Component.For<IShellWindow>().ImplementedBy<ShellView>());
			_container.Register(Component.For<IShellViewModel>().ImplementedBy<ShellViewModel>());
			_container.Register(Component.For<IMainScreen>().ImplementedBy<MainScreenViewModel>());

			_container.Register(AllTypes.FromThisAssembly().InSameNamespaceAs<ShellViewModel>());

			return _container.Resolve<IShellWindow>();

		}
	}

}
